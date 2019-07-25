//===============================================================================
// Microsoft Premier Support for Developers
// FeatureToggle Sample
//===============================================================================
// Copyright © Microsoft Corporation.  All rights reserved.
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
// OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
// LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
// FITNESS FOR A PARTICULAR PURPOSE.
//===============================================================================
using FeatureToggle.Core;
using System;
using System.Web.Mvc;

namespace FeatureToggleHtmlHelpers
{
    class DisposableHelper : IDisposable
    {
        private Action _end;

        public DisposableHelper(Action begin, Action end)
        {
            _end = end;
            begin();
        }

        public void Dispose()
        {
            _end();
        }
    }

    public static class FeatureToggleExtensions
    {
        public static IDisposable FeatureToggle(this HtmlHelper helper, IFeatureToggle toggle)
        {
            return new DisposableHelper(
                () => helper.WriteFeatureToggleBegin(toggle),
                () => helper.WriteFeatureToggleEnd(toggle)
            );
        }

        public static MvcHtmlString BeginFeatureToggle(this HtmlHelper helper, IFeatureToggle toggle)
        {
            if (toggle.FeatureEnabled)
            {
                return new MvcHtmlString(string.Empty);
            }
            else
            {
                return new MvcHtmlString("<span style=\"display:none\">");
            }
        }

        public static MvcHtmlString EndFeatureToggle(this HtmlHelper helper, IFeatureToggle toggle)
        {
            if (toggle.FeatureEnabled)
            {
                return new MvcHtmlString(string.Empty);
            }
            else
            {
                return new MvcHtmlString("</span>");
            }
        }

        static void WriteFeatureToggleBegin(this HtmlHelper helper, IFeatureToggle toggle)
        {
            if (!toggle.FeatureEnabled)
            {
                helper.ViewContext.Writer.Write("<span style=\"display:none\">");
            }
        }

        static void WriteFeatureToggleEnd(this HtmlHelper helper, IFeatureToggle toggle)
        {
            if (!toggle.FeatureEnabled)
            {
                helper.ViewContext.Writer.Write("</span>");
            }
        }
    }
}
