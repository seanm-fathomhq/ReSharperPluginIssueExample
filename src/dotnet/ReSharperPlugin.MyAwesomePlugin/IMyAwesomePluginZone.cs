using System.Runtime.InteropServices;
using JetBrains.ReSharper.Feature.Services.LiveTemplates.Hotspots;
using JetBrains.ReSharper.Feature.Services.LiveTemplates.Macros;

namespace ReSharperPlugin.MyAwesomePlugin
{
    [MacroDefinition("spacestounderstrokes2",
        LongDescription = "TEST: Changes spaces to '_' (i.e. \"do something useful\" into \"do_something_useful\"",
        ShortDescription = "TEST: Value of {#0:another variable}, where spaces will be replaced with '_'")]
    public class SpacesToUnderstrokes2MacroDef : SimpleMacroDefinition
    {
        public override ParameterInfo[] Parameters =>
            new ParameterInfo[1]
            {
                new(ParameterType.VariableReference)
            };
    }

    [MacroImplementation(Definition = typeof(SpacesToUnderstrokes2MacroDef))]
    public class SpacesToUnderstrokes2MacroImpl : SimpleMacroImplementation
    {
        private readonly IMacroParameterValueNew myArgument;

        public SpacesToUnderstrokes2MacroImpl([Optional] MacroParameterValueCollection arguments)
        {
            myArgument = arguments.OptionalFirstOrDefault();
        }

        public override string EvaluateQuickResult(IHotspotContext context) =>
            myArgument != null ? Execute(myArgument.GetValue()) : null;

        private static string Execute(string text)
        {
            if (text == null)
                return string.Empty;
            if (text.Length > 0)
                text = text.Replace(' ', '_');
            return text;
        }
    }
}
