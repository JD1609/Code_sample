using Microsoft.AspNetCore.Mvc;
using PhonebookContacts.Data.Exceptions;
using PhonebookContacts.Dto.Response;

namespace PhonebookContacts.Server.Controllers
{
    public abstract class BaseController<T> : Controller
    {
        protected readonly ILogger<T> _logger;


        #region Ctor
        public BaseController(ILogger<T> logger)
        {
            _logger = logger;
        }
        #endregion

        protected async Task<ActionResult<TResponse>> CallSafe<TResponse>(Func<Task<TResponse>> func) where TResponse : class, IResponse, new()
        {
            var guid = Guid.NewGuid();

            try
            {
                _logger.LogInformation($"Operation [{guid}] started");

                var response = await func();
                response.OperationGuid = guid.ToString();

                return Ok(response);
            }
            catch (BadRequestException e)
            {
                return BadRequest(new Response
                {
                    OperationGuid = guid.ToString(),
                    Message = e.Message
                });
            }
            catch (KeyNotFoundException e)
            {
                return NotFound(new Response
                {
                    OperationGuid = guid.ToString(),
                    Message = e.Message
                });
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);

                return StatusCode(500, new Response
                {
                    OperationGuid = guid.ToString(),
                    Message = e.Message // Dev option
                    //Message = $"Operation [{guid}] failed"
                });
            }
        }
    }
}
