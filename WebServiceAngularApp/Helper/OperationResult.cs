using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebServiceAngularApp.Helper
{
    public class OperationResult<TResult>
    {
        private OperationResult()
        {

        }

        public bool Success { get; private set; }
        public TResult Data { get; private set; }
        public string Message { get; private set; }
        public Exception Exception { get; private set; }

        public static OperationResult<TResult> CreateSuccessResult(TResult result)
        {
            return new OperationResult<TResult> { Success = true, Data = result };
        }

        public static OperationResult<TResult> CreateFailure(string nonSuccessMessage)
        {
            return new OperationResult<TResult> { Success = false, Message = nonSuccessMessage };
        }

        public static OperationResult<TResult> CreateFailure()
        {
            return new OperationResult<TResult> { Success = false, Message = "Hubo un problema inesperado. Espera un momento y vuelve a intentarlo." };
        }

        public static OperationResult<TResult> CreateFailure(Exception ex)
        {

            return new OperationResult<TResult>
            {
                Success = false,
                Message = String.Format("{0}{1}{1}{2}", ex.Message, Environment.NewLine, ex.StackTrace),
                Exception = ex
            };
        }

    }
}