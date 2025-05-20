// <copyright file="SimpleCalculatorController.cs" company="APIMatic">
// Copyright (c) APIMatic. All rights reserved.
// </copyright>
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using APIMatic.Core;
using APIMatic.Core.Types;
using APIMatic.Core.Utilities;
using APIMatic.Core.Utilities.Date.Xml;
using ApimaticCalculator.Standard;
using ApimaticCalculator.Standard.Http.Client;
using ApimaticCalculator.Standard.Utilities;
using Newtonsoft.Json.Converters;
using System.Net.Http;

namespace ApimaticCalculator.Standard.Controllers
{
    /// <summary>
    /// SimpleCalculatorController.
    /// </summary>
    public class SimpleCalculatorController : BaseController
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SimpleCalculatorController"/> class.
        /// </summary>
        internal SimpleCalculatorController(GlobalConfiguration globalConfiguration) : base(globalConfiguration) { }

        /// <summary>
        /// Calculates the expression using the specified operation.
        /// </summary>
        /// <param name="input">Object containing request parameters.</param>
        /// <returns>Returns the Models.OperationTypeEnum response from the API call.</returns>
        public Models.OperationTypeEnum GetCalculate(
                Models.GetCalculateInput input)
            => CoreHelper.RunTask(GetCalculateAsync(input));

        /// <summary>
        /// Calculates the expression using the specified operation.
        /// </summary>
        /// <param name="input">Object containing request parameters.</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.OperationTypeEnum response from the API call.</returns>
        public async Task<Models.OperationTypeEnum> GetCalculateAsync(
                Models.GetCalculateInput input,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.OperationTypeEnum>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Get, "/{operation}")
                  .Parameters(_parameters => _parameters
                      .Template(_template => _template.Setup("operation", ApiHelper.JsonSerialize(input.Operation).Trim('\"')))
                      .Query(_query => _query.Setup("x", input.X))
                      .Query(_query => _query.Setup("y", input.Y))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .Deserializer(_response => (Models.OperationTypeEnum)Enum.Parse(typeof(Models.OperationTypeEnum), _response)))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);
    }
}