﻿using DocumentFormat.OpenXml.Presentation;
using PdfSharp.Fonts;
using System.Reflection;

namespace BarberBoss.Application.UseCases.Invoicing.Reports.Pdf.Fonts;
public class InvoicingReportFontsResolve : IFontResolver
{
    public byte[]? GetFont(string faceName)
    {
        var stream = ReadFontFile(faceName);

        stream ??= ReadFontFile(FontHelper.DEFAULT_FONT);

        var length = (int)stream!.Length;

        var data = new byte[length];

        stream.Read(buffer: data, offset: 0, count: length);

        return data;
    }

    public FontResolverInfo? ResolveTypeface(string familyName, bool bold, bool italic)
    {
        return new FontResolverInfo(familyName);
    }

    private Stream? ReadFontFile(string facename)
    {
        var assembly = Assembly.GetExecutingAssembly();

        return assembly.GetManifestResourceStream($"BarberBoss.Application.UseCases.Expenses.Reports.Pdf.Fonts.{facename}.ttf");
    }
}
