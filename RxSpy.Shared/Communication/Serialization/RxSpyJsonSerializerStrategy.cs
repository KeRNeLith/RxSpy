﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RxSpy.Events;
using RxSpy.Models.Events;

namespace RxSpy.Communication.Serialization
{
    public class RxSpyJsonSerializerStrategy: PocoJsonSerializerStrategy
    {
        public override object DeserializeObject(object value, Type type)
        {
            if (type.IsEnum)
            {
                return Enum.Parse(type, (string)value);
            }

            var obj = value as IDictionary<string, object>;

            if (obj == null)
                return base.DeserializeObject(value, type);

            if (type == typeof(IEvent))
            {
                var eventType = (EventType)DeserializeObject(obj["EventType"], typeof(EventType));

                switch (eventType)
                {
                    case EventType.OperatorCreated: return base.DeserializeObject(value, typeof(OperatorCreatedEvent));
                    case EventType.Subscribe: return base.DeserializeObject(value, typeof(SubscribeEvent));
                    case EventType.Unsubscribe: return base.DeserializeObject(value, typeof(UnsubscribeEvent));
                    case EventType.OnNext: return base.DeserializeObject(value, typeof(OnNextEvent));
                    case EventType.OnError: return base.DeserializeObject(value, typeof(OnErrorEvent));
                    case EventType.OnCompleted: return base.DeserializeObject(value, typeof(OnCompletedEvent));
                    case EventType.TagOperator: return base.DeserializeObject(value, typeof(TagOperatorEvent));
                    case EventType.Connected: return base.DeserializeObject(value, typeof(ConnectedEvent));
                    case EventType.Disconnected: return base.DeserializeObject(value, typeof(DisconnectedEvent));
                    default: throw new NotImplementedException();
                }
            }

            if (type == typeof(ICallSite))
                return base.DeserializeObject(value, typeof(CallSite));

            if (type == typeof(IMethodInfo))
                return base.DeserializeObject(value, typeof(MethodInfo));

            if (type == typeof(ITypeInfo))
                return base.DeserializeObject(value, typeof(TypeInfo));

            return base.DeserializeObject(value, type);
        }

        protected override object SerializeEnum(Enum p)
        {
            return Enum.GetName(p.GetType(), p);
        }
    }
}
