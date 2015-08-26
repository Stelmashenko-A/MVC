using System;
using System.Diagnostics;
using System.Text;
using PostSharp.Aspects;

namespace MVC.AOP
{
    [Serializable]
    public class LogAspect : OnMethodBoundaryAspect
    {
        [NonSerialized]
        private Stopwatch _stopWatch;

        [NonSerialized]
        private IConverter _converter = new JsonConverter();


        
        public override void OnEntry(MethodExecutionArgs args)
        {
            _stopWatch = Stopwatch.StartNew();
            _converter = new JsonConverter();
            var stringBuilder = new StringBuilder().AppendFormat("{0} [", args.Method.Name);

            for (var index = 0; index < args.Arguments.Count; index++)
            {
                var arg = args.Arguments.GetArgument(index);
                stringBuilder.AppendFormat("({0}: {1}) ", args.Method.GetParameters()[index].ParameterType.Name,
                    _converter.Convert(arg));
            }
            MvcApplication.Log.Info(stringBuilder.Append(']').ToString());
            base.OnEntry(args);
        }

        public override void OnSuccess(MethodExecutionArgs args)
        {
            _converter = new JsonConverter();
            MvcApplication.Log.Info(_converter.Convert(args.ReturnValue) + " [Elapsed time: " + _stopWatch.ElapsedMilliseconds + ']');

        }

        public override void OnException(MethodExecutionArgs args)
        {
            args.FlowBehavior = FlowBehavior.Continue;
            MvcApplication.Log.Error(args.Exception.Message, args.Exception);
            throw args.Exception;
        }
    }
}