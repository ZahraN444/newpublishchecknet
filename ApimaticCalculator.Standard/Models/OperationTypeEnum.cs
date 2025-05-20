// <copyright file="OperationTypeEnum.cs" company="APIMatic">
// Copyright (c) APIMatic. All rights reserved.
// </copyright>
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using APIMatic.Core.Utilities.Converters;
using ApimaticCalculator.Standard;
using ApimaticCalculator.Standard.Utilities;
using Newtonsoft.Json;

namespace ApimaticCalculator.Standard.Models
{
    /// <summary>
    /// OperationTypeEnum.
    /// </summary>

    [JsonConverter(typeof(StringEnumConverter))]
    public enum OperationTypeEnum
    {
        /// <summary>
        ///Represents the sum operator
        /// SUM.
        /// </summary>
        [EnumMember(Value = "SUM")]
        SUM,

        /// <summary>
        ///Represents the subtract operator
        /// SUBTRACT.
        /// </summary>
        [EnumMember(Value = "SUBTRACT")]
        SUBTRACT,

        /// <summary>
        ///Represents the multiply operator
        /// MULTIPLY.
        /// </summary>
        [EnumMember(Value = "MULTIPLY")]
        MULTIPLY,

        /// <summary>
        ///Represents the divide operator
        /// DIVIDE.
        /// </summary>
        [EnumMember(Value = "DIVIDE")]
        DIVIDE
    }
}