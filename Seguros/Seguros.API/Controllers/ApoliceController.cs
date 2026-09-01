using Amazon.S3;
using Amazon.S3.Model;
using Microsoft.AspNetCore.Mvc;
using Seguros.Application.DTOs.Apolice;
using Seguros.Application.DTOs.ArquivoApolice;
using Seguros.Application.Interfaces;

namespace Seguros.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UploadApoliceRequest
    {
        public string NomeArquivo { get; set; } = string.Empty;
        public string ContentType { get; set; } = "application/pdf";
    }
    public class ApoliceController : Controller
    {
        private readonly IApoliceService _apoliceService;
        private readonly IArquivoApoliceService _arquivoApoliceService;
        private readonly IAmazonS3 _s3;
        public ApoliceController(
            IApoliceService apoliceService,
            IArquivoApoliceService arquivoApoliceService,
            IAmazonS3 s3)
        {
            _apoliceService = apoliceService;
            _arquivoApoliceService = arquivoApoliceService;
            _s3 = s3;
        }

        [HttpPost]
        public async Task<ActionResult> CreateApolice(ApolicePostDTO apolicePostDTO)
        {
            var createdApolice = await _apoliceService.AddAsync(apolicePostDTO);
            if (createdApolice == null)
            {
                return BadRequest("Não foi possível criar a apólice.");
            }
            return Ok(new { message = "Apólice criada com sucesso.", createdApolice });
        }

        [HttpPut]
        public async Task<ActionResult> UpdateApolice(ApolicePutDTO apolicePutDTO)
        {
            var updatedApolice = await _apoliceService.UpdateAsync(apolicePutDTO);
            if (updatedApolice == null)
            {
                return BadRequest("Não foi possível atualizar a apólice.");
            }
            return Ok(new { message = "Apólice atualizada com sucesso." });
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteApolice(int id)
        {
            var deleted = await _apoliceService.DeleteAsync(id);
            if (deleted == null)
            {
                return BadRequest("Não foi possível deletar a apólice.");
            }
            return Ok(new { message = "Apólice deletada com sucesso." });
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetApolice(int id)
        {
            var apolice = await _apoliceService.GetByIdAsync(id);
            if (apolice == null)
            {
                return NotFound("Apólice não encontrada.");
            }
            return Ok(apolice);
        }

        [HttpGet("getAll")]
        public async Task<ActionResult> GetAllApolices()
        {
            var apolices = await _apoliceService.GetAllAsync();
            return Ok(apolices);
        }

        [HttpGet("details")]
        public async Task<ActionResult> GetAllApolicesDetails()
        {
            var apolices = await _apoliceService.GetAllDetailsAsync();
            return Ok(apolices);
        }

        [HttpGet("details/{id}")]
        public async Task<ActionResult> GetApoliceDetails(int id)
        {
            var apolice = await _apoliceService.GetDetailsByIdAsync(id);
            if (apolice == null)
            {
                return NotFound("Apólice não encontrada.");
            }
            return Ok(apolice);
        }
        [HttpGet("{id:int}/arquivos")]
        public async Task<ActionResult> GetApoliceArquivos(int id)
        {
            var arquivos =
                await _arquivoApoliceService.GetByApoliceIdAsync(id);

            return Ok(arquivos);
        }

        [HttpGet("{id:int}/arquivos/{arquivoId:int}/download")]
        public async Task<ActionResult> GetArquivoDownload(
            int id,
            int arquivoId)
        {
            var arquivo =
                await _arquivoApoliceService.GetByIdAsync(id, arquivoId);

            var request = new GetPreSignedUrlRequest
            {
                BucketName = "MyBucket",
                Key = arquivo.CaminhoArquivo,
                Verb = HttpVerb.GET,
                Expires = DateTime.UtcNow.AddMinutes(5)
            };
            var urlAssinada = _s3.GetPreSignedURL(request);
            return Ok(new
            {
                url = urlAssinada,
                expiraEmSegundos = 300
            });
        }

        [HttpDelete("{id:int}/arquivos/{arquivoId:int}")]
        public async Task<ActionResult> ExcluirArquivo(
            int id,
            int arquivoId)
        {
            var arquivo =
                await _arquivoApoliceService.GetByIdAsync(id, arquivoId);

            await _s3.DeleteObjectAsync(new DeleteObjectRequest
            {
                BucketName = "MyBucket",
                Key = arquivo.CaminhoArquivo
            });

            await _arquivoApoliceService.DeleteAsync(id, arquivoId);

            return Ok(new
            {
                message = "Arquivo excluído com sucesso."
            });
        }

        [HttpPost("{id:int}/upload-url")]
        public async Task<ActionResult> GerarUrlUpload(int id,
            [FromBody] UploadApoliceRequest request)
        {
            var apolice = await _apoliceService.GetByIdAsync(id);

            if (apolice == null)
            {
                return NotFound("Apólice não encontrada.");
            }

            if (string.IsNullOrWhiteSpace(request.NomeArquivo))
            {
                return BadRequest("O nome do arquivo é obrigatório.");
            }

            var nomeArquivo = Path.GetFileName(request.NomeArquivo);

            var caminhoArquivo =
                $"apolices/{id}/{Guid.NewGuid()}-{nomeArquivo}";

            var presignedRequest = new GetPreSignedUrlRequest
            {
                BucketName = "MyBucket",
                Key = caminhoArquivo,
                Verb = HttpVerb.PUT,
                ContentType = request.ContentType,
                Expires = DateTime.UtcNow.AddMinutes(10)
            };

            var urlAssinada =
                _s3.GetPreSignedURL(presignedRequest);

            return Ok(new
            {
                url = urlAssinada,
                caminhoArquivo,
                contentType = request.ContentType
            });
        }

        [HttpPost("{id:int}/arquivos")]
        public async Task<ActionResult> ConfirmarUpload(
            int id,
            [FromBody] ArquivoApolicePostDTO request)
        {
            var arquivo =
                await _arquivoApoliceService.AddAsync(id, request);

            return Ok(arquivo);
        }

    }
};
