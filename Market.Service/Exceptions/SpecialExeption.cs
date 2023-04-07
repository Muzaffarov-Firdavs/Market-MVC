﻿namespace Market.Service.Exceptions
{
    public class SpecialExeption : Exception
    {
        public int? StatusCode { get; set; } 

        public SpecialExeption(int? statusCode = null, string message = null)
            this.StatusCode = statusCode;
        }

    }
}