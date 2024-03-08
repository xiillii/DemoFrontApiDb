namespace SportsStore.MvcClient.Services.Base;

public class BaseHttpService
{
    protected IClient _client;

    public BaseHttpService(IClient client)
    {
        _client = client;   
    }

    protected Response ConvertApiExceptions(ApiException ex)
    {
        if (ex.StatusCode == 400)
        {
            return new Response()
            {
                Message = "Invalid data was submitted.",
                ValidationErrors = ex.Response,
                Success = false,
            };
        }
        else if (ex.StatusCode == 404)
        {
            return new Response()
            {
                Message = "The record was not found.",
                Success = false,
            };
        }
        else
        {
            return new Response
            {
                Message = "Something went wrong, please try again later",
                Success = false,
            };
        }
    }

    protected Response<Guid> ConvertApiExceptions<Guid>(ApiException ex)
    {
        if (ex.StatusCode == 400)
        {
            return new Response<Guid>()
            {
                Message = "Invalid data was submitted.",
                ValidationErrors = ex.Response,
                Success = false,
            };
        }
        else if (ex.StatusCode == 404)
        {
            return new Response<Guid>()
            {
                Message = "The record was not found.",
                Success = false,
            };
        }
        else
        {
            return new Response<Guid>
            {
                Message = "Something went wrong, please try again later",
                Success = false,
            };
        }
    }


}