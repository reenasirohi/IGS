﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IGSService.Models
{
    public class ApiResponse
    {

        public int StatusCode { get; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Message { get; }

        public ApiResponse(int statusCode, string message = null)
        {
            StatusCode = statusCode;
            Message = message ?? GetDefaultMessageForStatusCode(statusCode);
        }

        private static string GetDefaultMessageForStatusCode(int statusCode)
        {
            switch (statusCode)
            {             
             case 200:
                  return "Successfull Request";
            case 404:
                return "UnSuccessfull Request Record not found";
            case 500:
                return "An unhandled error occurred";
            default:
                return null;
        }
    }
}
}
