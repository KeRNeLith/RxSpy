﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RxSpy.Utils;

namespace RxSpy.Events
{
    internal class OnNextEvent : Event
    {
        public long OperatorId { get; private set; }
        public string ValueType { get; private set; }
        public string Value { get; private set; }

        public OnNextEvent(OperatorInfo operatorInfo, Type valueType, object value)
            : base(EventType.OnNext)
        {
            OperatorId = operatorInfo.Id;
            ValueType = TypeUtils.ToFriendlyName(valueType);
            Value = GetValueRepresentation(value);
        }

        string GetValueRepresentation(object value)
        {
            // TODO: Do something cool with DebuggerDisplay if present
            return (value ?? "null").ToString();
        }

    }
}