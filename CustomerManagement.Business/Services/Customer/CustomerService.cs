using CustomerManagement.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.Business.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly HttpClient _httpClient;
        private readonly string apiBaseUrl;
        private readonly IApiSettings _appSettings;

        public CustomerService(HttpClient httpClient, IApiSettings appSettings)
        {
            _httpClient = httpClient;
            _appSettings = appSettings;
            apiBaseUrl = _appSettings.ApiBaseUrl;   
        }

        public async Task<Customer> ReadById(long id)
        {
            var response = await _httpClient.GetAsync($"{apiBaseUrl}{id}");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<Customer>();
            }
            else
            {
                throw new HttpRequestException($"Failed to fetch customer with ID {id}. Status code: {response.StatusCode}");
            }
        }

        public async Task<List<Customer>> List()
        {
            var response = await _httpClient.GetAsync(apiBaseUrl + "list");
            if (response.IsSuccessStatusCode)
            {
                var result =  await response.Content.ReadFromJsonAsync<List<Customer>>();
                return await Task.FromResult(result);
            }
            else
            {
                throw new HttpRequestException("Failed to fetch customers. Status code: {response.StatusCode}");
            }
        }

        public async Task<CustomerResponse> Create(Customer request)
        {
            var response = await _httpClient.PostAsJsonAsync(apiBaseUrl + "Create", new CreateCustomerRequest
            {
                Identifier = request.Identifier,
                Category = request.Category,
                FirstName = request.FirstName,
                LastName = request.LastName,
                ContactName = request.ContactName,
                PhoneNumber = request.PhoneNumber,
                Address = request.Address,

            });

            if (response.IsSuccessStatusCode)
            {
                var result =  await response.Content.ReadFromJsonAsync<CustomerResponse>();
                return await Task.FromResult(result);
            }
            else
            {
                var result = await response.Content.ReadFromJsonAsync<CustomerResponse>();

                    return await Task.FromResult(new CustomerResponse
                    {
                        HasError = true,
                        ErrorMessage = result.ErrorMessage
                    });
            }
        }

        public async Task<CustomerResponse> Update(Customer request)
        {
            var response = await _httpClient.PutAsJsonAsync($"{apiBaseUrl}Update", new UpdateCustomerRequest
            {
                Id = request.Id,
                Identifier = request.Identifier,
                Category = request.Category,
                FirstName = request.FirstName,
                LastName = request.LastName,
                ContactName = request.ContactName,
                PhoneNumber = request.PhoneNumber,
                Address = request.Address,

            });


            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<CustomerResponse>();
                return await Task.FromResult(result);
            }
            else
            {
                var result = await response.Content.ReadFromJsonAsync<CustomerResponse>();

                return await Task.FromResult(new CustomerResponse
                {
                    HasError = true,
                    ErrorMessage = result.ErrorMessage
                });
            }

        }

        public async Task Delete(long id)
        {
            var response = await _httpClient.DeleteAsync($"{apiBaseUrl}{id}");
            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"Failed to delete customer with ID {id}. Status code: {response.StatusCode}");
            }
        }
    }
}
