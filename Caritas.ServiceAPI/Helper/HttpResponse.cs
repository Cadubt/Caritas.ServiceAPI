using Caritas.ServiceAPI.Models.Responses;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace Caritas.ServiceAPI.Helper
{
    public class HttpResponse
    {
        private static readonly Dictionary<int, ResponseStatus> RFCResponses = new Dictionary<int, ResponseStatus>(){
            { 100, new ResponseStatus { Code = 100, Class = ResponseClass.InformationalResponse, Reason = "Continue" } },
            { 101, new ResponseStatus { Code = 101, Class = ResponseClass.InformationalResponse, Reason = "Switching Protocol" } },
            { 102, new ResponseStatus { Code = 102, Class = ResponseClass.InformationalResponse, Reason = "Processing" } },
            { 200, new ResponseStatus { Code = 200, Class = ResponseClass.SuccessfulResponse, Reason = "OK" } },
            { 201, new ResponseStatus { Code = 201, Class = ResponseClass.SuccessfulResponse, Reason = "Created" } },
            { 202, new ResponseStatus { Code = 202, Class = ResponseClass.SuccessfulResponse, Reason = "Accepted" } },
            { 203, new ResponseStatus { Code = 203, Class = ResponseClass.SuccessfulResponse, Reason = "Non-Authoritative Information" } },
            { 204, new ResponseStatus { Code = 204, Class = ResponseClass.SuccessfulResponse, Reason = "No Content" } },
            { 205, new ResponseStatus { Code = 205, Class = ResponseClass.SuccessfulResponse, Reason = "Reset Content" } },
            { 206, new ResponseStatus { Code = 206, Class = ResponseClass.SuccessfulResponse, Reason = "Partial Content" } },
            { 207, new ResponseStatus { Code = 207, Class = ResponseClass.SuccessfulResponse, Reason = "Multi-Status" } },
            { 208, new ResponseStatus { Code = 208, Class = ResponseClass.SuccessfulResponse, Reason = "Multi-Status" } },
            { 226, new ResponseStatus { Code = 226, Class = ResponseClass.SuccessfulResponse, Reason = "IM Used" } },
            { 300, new ResponseStatus { Code = 300, Class = ResponseClass.Redirect, Reason = "Multiple Choice" } },
            { 301, new ResponseStatus { Code = 301, Class = ResponseClass.Redirect, Reason = "Moved Permanently" } },
            { 302, new ResponseStatus { Code = 302, Class = ResponseClass.Redirect, Reason = "Found" } },
            { 303, new ResponseStatus { Code = 303, Class = ResponseClass.Redirect, Reason = "See Other" } },
            { 304, new ResponseStatus { Code = 304, Class = ResponseClass.Redirect, Reason = "Not Modified" } },
            { 305, new ResponseStatus { Code = 305, Class = ResponseClass.Redirect, Reason = "Use Proxy" } },
            { 306, new ResponseStatus { Code = 306, Class = ResponseClass.Redirect, Reason = "unused" } },
            { 307, new ResponseStatus { Code = 307, Class = ResponseClass.Redirect, Reason = "Temporary Redirect" } },
            { 308, new ResponseStatus { Code = 308, Class = ResponseClass.Redirect, Reason = "Permanent Redirect" } },
            { 400, new ResponseStatus { Code = 400, Class = ResponseClass.ClientError, Reason = "Bad Request" } },
            { 401, new ResponseStatus { Code = 401, Class = ResponseClass.ClientError, Reason = "Unauthorized" } },
            { 402, new ResponseStatus { Code = 402, Class = ResponseClass.ClientError, Reason = "Payment Required" } },
            { 403, new ResponseStatus { Code = 403, Class = ResponseClass.ClientError, Reason = "Forbidden" } },
            { 404, new ResponseStatus { Code = 404, Class = ResponseClass.ClientError, Reason = "Not Found" } },
            { 405, new ResponseStatus { Code = 405, Class = ResponseClass.ClientError, Reason = "Method Not Allowed" } },
            { 406, new ResponseStatus { Code = 406, Class = ResponseClass.ClientError, Reason = "Not Acceptable" } },
            { 407, new ResponseStatus { Code = 407, Class = ResponseClass.ClientError, Reason = "Proxy Authentication Required" } },
            { 408, new ResponseStatus { Code = 408, Class = ResponseClass.ClientError, Reason = "Request Timeout" } },
            { 409, new ResponseStatus { Code = 409, Class = ResponseClass.ClientError, Reason = "Conflict" } },
            { 410, new ResponseStatus { Code = 410, Class = ResponseClass.ClientError, Reason = "Gone" } },
            { 411, new ResponseStatus { Code = 411, Class = ResponseClass.ClientError, Reason = "Length Required" } },
            { 412, new ResponseStatus { Code = 412, Class = ResponseClass.ClientError, Reason = "Precondition Failed" } },
            { 413, new ResponseStatus { Code = 413, Class = ResponseClass.ClientError, Reason = "Payload Too Large" } },
            { 414, new ResponseStatus { Code = 414, Class = ResponseClass.ClientError, Reason = "URI Too Long" } },
            { 415, new ResponseStatus { Code = 415, Class = ResponseClass.ClientError, Reason = "Unsupported Media Type" } },
            { 416, new ResponseStatus { Code = 416, Class = ResponseClass.ClientError, Reason = "Requested Range Not Satisfiable" } },
            { 417, new ResponseStatus { Code = 417, Class = ResponseClass.ClientError, Reason = "Expectation Failed" } },
            { 418, new ResponseStatus { Code = 418, Class = ResponseClass.ClientError, Reason = "I'm a teapot" } },
            { 421, new ResponseStatus { Code = 421, Class = ResponseClass.ClientError, Reason = "Misdirected Request" } },
            { 422, new ResponseStatus { Code = 422, Class = ResponseClass.ClientError, Reason = "Unprocessable Entity" } },
            { 423, new ResponseStatus { Code = 423, Class = ResponseClass.ClientError, Reason = "Locked" } },
            { 424, new ResponseStatus { Code = 424, Class = ResponseClass.ClientError, Reason = "Failed Dependency" } },
            { 426, new ResponseStatus { Code = 426, Class = ResponseClass.ClientError, Reason = "Upgrade Required" } },
            { 428, new ResponseStatus { Code = 428, Class = ResponseClass.ClientError, Reason = "Precondition Required" } },
            { 429, new ResponseStatus { Code = 429, Class = ResponseClass.ClientError, Reason = "Too Many Requests" } },
            { 431, new ResponseStatus { Code = 431, Class = ResponseClass.ClientError, Reason = "Request Header Fields Too Large" } },
            { 451, new ResponseStatus { Code = 451, Class = ResponseClass.ClientError, Reason = "Unavailable For Legal Reasons" } },
            { 500, new ResponseStatus { Code = 500, Class = ResponseClass.ServerError, Reason = "Internal Server Error" } },
            { 501, new ResponseStatus { Code = 501, Class = ResponseClass.ServerError, Reason = "Not Implemented" } },
            { 502, new ResponseStatus { Code = 502, Class = ResponseClass.ServerError, Reason = "Bad Gateway" } },
            { 503, new ResponseStatus { Code = 503, Class = ResponseClass.ServerError, Reason = "Service Unavailable" } },
            { 504, new ResponseStatus { Code = 504, Class = ResponseClass.ServerError, Reason = "Gateway Timeout" } },
            { 505, new ResponseStatus { Code = 505, Class = ResponseClass.ServerError, Reason = "HTTP Version Not Supported" } },
            { 506, new ResponseStatus { Code = 506, Class = ResponseClass.ServerError, Reason = "Variant Also Negotiates" } },
            { 507, new ResponseStatus { Code = 507, Class = ResponseClass.ServerError, Reason = "Insufficient Storage" } },
            { 508, new ResponseStatus { Code = 508, Class = ResponseClass.ServerError, Reason = "Loop Detected" } },
            { 510, new ResponseStatus { Code = 510, Class = ResponseClass.ServerError, Reason = "Not Extended" } },
            { 511, new ResponseStatus { Code = 511, Class = ResponseClass.ServerError, Reason = "Network Authentication Required" } }
        };

        public static ActionResult Send(bool success, int code = 200, dynamic data = null, string message = null)
        {
            ResponseModel response = new ResponseModel();

            if (RFCResponses.ContainsKey(code))
            {
                response.Code = code;
                response.Type = RFCResponses[code].Class;

                if (RFCResponses[code].Class == ResponseClass.SuccessfulResponse || RFCResponses[code].Class == ResponseClass.InformationalResponse)
                {
                    response.Success = true;
                    response.Error = null;
                    response.Data = data;
                }
                else
                {
                    response.Data = null;
                    response.Type = RFCResponses[code].Class;
                    response.Error = new
                    {
                        Message = RFCResponses[response.Code].Reason,
                        InternalMesasge = message
                    };
                }
            }
            else
            {
                response.Success = false;
                response.Code = 500;
                response.Type = RFCResponses[response.Code].Class;
                response.Data = null;

                switch (code)
                {
                    case 640:
                        response.Code = 400;
                        response.Type = RFCResponses[response.Code].Class;
                        response.Error = message;
                        break;
                    case 650:
                        response.Code = 500;
                        response.Type = RFCResponses[response.Code].Class;
                        if (String.IsNullOrEmpty(message))
                        {
                            response.Error = RFCResponses[response.Code].Reason;
                        }
                        else
                        {
                            response.Error = message;
                        }
                        break;
                    default:
                        response.Error = RFCResponses[response.Code].Reason;
                        break;
                }
            }

            ObjectResult result = new ObjectResult(response);
            result.StatusCode = response.Code;
            return result;
        }
    }
}
