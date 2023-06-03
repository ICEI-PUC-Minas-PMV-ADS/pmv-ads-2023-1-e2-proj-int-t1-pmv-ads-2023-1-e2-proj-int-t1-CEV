using cev.api.Domain.ModelsApi;
using Flunt.Notifications;
using Microsoft.AspNetCore.Mvc;

namespace cev.api.Controllers
{
    public abstract class ApiBaseController : ControllerBase
    {
        protected BadRequestObjectResult BadRequest(IReadOnlyCollection<Notification> notifications)
        {
            return new BadRequestObjectResult(new ErrorModel(notifications));
        }

        protected UnprocessableEntityObjectResult UnprocessableEntitiy(IReadOnlyCollection<Notification> notifications)
        {
            return new UnprocessableEntityObjectResult(new ErrorModel(notifications));
        }

        protected NotFoundObjectResult NotFound(string message)
        {
            return new NotFoundObjectResult(new ErrorModel(message));
        }
    }
}
