﻿using ActiproSoftware.Text.Tagging;
using ActiproSoftware.Text.Tagging.Implementation;
using ActiproSoftware.Windows.Controls.SyntaxEditor;
using ActiproSoftware.Windows.Controls.SyntaxEditor.Adornments.Implementation;
using ActiproSoftware.Windows.Controls.SyntaxEditor.IntelliPrompt;
using ActiproSoftware.Windows.Controls.SyntaxEditor.IntelliPrompt.Implementation;
using ActiproSoftware.Windows.Controls.SyntaxEditor.Outlining;
using Raven.Studio.Controls;
using ActiproSoftware.Text;

namespace Raven.Studio.Features.JsonEditor
{
    public class JsonSyntaxLanguageExtended : JsonSyntaxLanguage
    {
        public JsonSyntaxLanguageExtended() : base()
        { 
            RegisterService<IOutliner>(new JsonOutliner());

            this.RegisterParser(new JsonParser());

            RegisterService<ITextFormatter>(new JsonTextFormatter());

            RegisterService(new TextViewTaggerProvider<WordHighlightTagger>(typeof(WordHighlightTagger)));

            // Register a tagger provider for showing parse errors
            RegisterService<ICodeDocumentTaggerProvider>(new CodeDocumentTaggerProvider<ParseErrorTagger>(typeof(ParseErrorTagger)));

            // Register a squiggle tag quick info provider
            RegisterService<IQuickInfoProvider>(new SquiggleTagQuickInfoProvider());

            RegisterService(new AdornmentManagerProvider<LinkTagAdornmentManager>(typeof(LinkTagAdornmentManager)));

            RegisterService(new CodeDocumentTaggerProvider<PropertyValueLinkTagger>(typeof(PropertyValueLinkTagger)));

            RegisterService<IEditorViewMouseInputEventSink>(new LinkTagClickHandler());

            RegisterService<IQuickInfoProvider>(new LinkTagQuickInfoProvider());
        }
    }
}
