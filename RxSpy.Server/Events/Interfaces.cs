﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RxSpy.Events
{
    public interface IEvent
    {
        EventType Type { get; }
        long EventId { get; }
        long EventTime { get; }
    }

    public interface ICallSite
    {
        string File { get; }
        int ILOffset { get; }
        int Line { get; }
        IMethodInfo Method { get; }
    }

    public interface IMethodInfo
    {
        string DeclaringType { get; }
        string Name { get; }
        string Namespace { get; }
        string Signature { get; }
    }

    public interface IOperatorCreatedEvent : IEvent
    {
        long Id { get; }
        string Name { get; }
        ICallSite CallSite { get; }
        IMethodInfo OperatorMethod { get; }
    }

    public interface IOnNextEvent : IEvent
    {
        long OperatorId { get; }
        string ValueType { get; }
        string Value { get; }
    }

    public interface IOnErrorEvent : IEvent
    {
        Type ErrorType { get; }
        string Message { get; }
        long OperatorId { get; }
    }

    public interface IOnCompletedEvent : IEvent
    {
        long OperatorId { get; }
    }
}