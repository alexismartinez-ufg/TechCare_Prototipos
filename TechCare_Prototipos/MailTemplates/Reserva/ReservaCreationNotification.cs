#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TechCare_Prototipos.MailTemplates
{
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


[System.CodeDom.Compiler.GeneratedCodeAttribute("RazorTemplatePreprocessor", "17.8.0.155")]
public partial class ReservaCreationNotification : ReservaCreationNotificationBase
{

#line hidden

#line 1 "ReservaCreationNotification.cshtml"
public Prototipos.DAL.ViewModels.ReservaNotificationViewModel Model { get; set; }

#line default
#line hidden


public override void Execute()
{
WriteLiteral("<body");

WriteLiteral(" style=\"font-family: Arial, sans-serif;background-color: #f4f4f4;margin: 10px 0px" +
";padding: 0;\"");

WriteLiteral(">\r\n    <div");

WriteLiteral(" style=\" max-width: 600px;margin: 20px auto; background-color: #ffffff; padding: " +
"20px; border-radius: 10px; box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);\"");

WriteLiteral(">\r\n        <h1");

WriteLiteral(" style=\" color: #333333;\"");

WriteLiteral(">¡Reserva Exitosa!</h1>\r\n        <p");

WriteLiteral(" style=\"color: #555555;\"");

WriteLiteral(">Estimado/a ");


#line 6 "ReservaCreationNotification.cshtml"
                                         Write(Model.PersonaACargo);


#line default
#line hidden
WriteLiteral(",</p>\r\n        <p");

WriteLiteral(" style=\"color: #555555;\"");

WriteLiteral(">Su reserva ha sido realizada con éxito. Aquí están los detalles:</p>\r\n\r\n        " +
"<div");

WriteLiteral(" style=\" margin-top: 20px;\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" style=\"font-weight: bold;margin-bottom: 5px;margin-top: 15px;\"");

WriteLiteral(">Mesa:</div>\r\n            <div");

WriteLiteral(" style=\"color: #007bff;\"");

WriteLiteral(">\r\n");

WriteLiteral("                ");


#line 12 "ReservaCreationNotification.cshtml"
           Write(Model.MesaSeleccionada.NombreMesa);


#line default
#line hidden
WriteLiteral(" (Para ");


#line 12 "ReservaCreationNotification.cshtml"
                                                    Write(Model.MesaSeleccionada.Personas);


#line default
#line hidden
WriteLiteral("\r\n                personas) en la zona ");


#line 13 "ReservaCreationNotification.cshtml"
                                Write(Model.MesaSeleccionada.Zona.NombreZona);


#line default
#line hidden
WriteLiteral("\r\n            </div>\r\n\r\n            <div");

WriteLiteral(" style=\"font-weight: bold;margin-bottom: 5px;margin-top: 15px;\"");

WriteLiteral(">Persona a Cargo:</div>\r\n            <div");

WriteLiteral(" style=\"color: #007bff;\"");

WriteLiteral(">");


#line 17 "ReservaCreationNotification.cshtml"
                                    Write(Model.PersonaACargo);


#line default
#line hidden
WriteLiteral("</div>\r\n\r\n            <div");

WriteLiteral(" style=\"font-weight: bold;margin-bottom: 5px;margin-top: 15px;\"");

WriteLiteral(">Fecha Reservada:</div>\r\n            <div");

WriteLiteral(" style=\"color: #007bff;\"");

WriteLiteral(">");


#line 20 "ReservaCreationNotification.cshtml"
                                    Write(Model.FechaReservada.ToString("dd/MM/yyyy HH:mm"));


#line default
#line hidden
WriteLiteral("</div>\r\n\r\n            <p");

WriteLiteral(" style=\"color: #28a745;font-weight: bold;margin-top: 10px;\"");

WriteLiteral(">¡Gracias por elegir el servicio TechCare!</p>\r\n            <p");

WriteLiteral(" style=\"color: #32643e;font-weight: bold;margin-top: 10px;\"");

WriteLiteral(">Procurar asistir minimo 15 minutos antes de la reserva o la mesa sera reasignada" +
".</p>\r\n        </div>\r\n    </div>\r\n</body>");

}
}

// NOTE: this is the default generated helper class. You may choose to extract it to a separate file 
// in order to customize it or share it between multiple templates, and specify the template's base 
// class via the @inherits directive.
public abstract class ReservaCreationNotificationBase
{

		// This field is OPTIONAL, but used by the default implementation of Generate, Write, WriteAttribute and WriteLiteral
		//
		System.IO.TextWriter __razor_writer;

		// This method is OPTIONAL
		//
		/// <summary>Executes the template and returns the output as a string.</summary>
		/// <returns>The template output.</returns>
		public string GenerateString ()
		{
			using (var sw = new System.IO.StringWriter ()) {
				Generate (sw);
				return sw.ToString ();
			}
		}

		// This method is OPTIONAL, you may choose to implement Write and WriteLiteral without use of __razor_writer
		// and provide another means of invoking Execute.
		//
		/// <summary>Executes the template, writing to the provided text writer.</summary>
		/// <param name="writer">The TextWriter to which to write the template output.</param>
		public void Generate (System.IO.TextWriter writer)
		{
			__razor_writer = writer;
			Execute ();
			__razor_writer = null;
		}

		// This method is REQUIRED, but you may choose to implement it differently
		//
		/// <summary>Writes a literal value to the template output without HTML escaping it.</summary>
		/// <param name="value">The literal value.</param>
		protected void WriteLiteral (string value)
		{
			__razor_writer.Write (value);
		}

		// This method is REQUIRED if the template contains any Razor helpers, but you may choose to implement it differently
		//
		/// <summary>Writes a literal value to the TextWriter without HTML escaping it.</summary>
		/// <param name="writer">The TextWriter to which to write the literal.</param>
		/// <param name="value">The literal value.</param>
		protected static void WriteLiteralTo (System.IO.TextWriter writer, string value)
		{
			writer.Write (value);
		}

		// This method is REQUIRED, but you may choose to implement it differently
		//
		/// <summary>Writes a value to the template output, HTML escaping it if necessary.</summary>
		/// <param name="value">The value.</param>
		/// <remarks>The value may be a Action<System.IO.TextWriter>, as returned by Razor helpers.</remarks>
		protected void Write (object value)
		{
			WriteTo (__razor_writer, value);
		}

		// This method is REQUIRED if the template contains any Razor helpers, but you may choose to implement it differently
		//
		/// <summary>Writes an object value to the TextWriter, HTML escaping it if necessary.</summary>
		/// <param name="writer">The TextWriter to which to write the value.</param>
		/// <param name="value">The value.</param>
		/// <remarks>The value may be a Action<System.IO.TextWriter>, as returned by Razor helpers.</remarks>
		protected static void WriteTo (System.IO.TextWriter writer, object value)
		{
			if (value == null)
				return;

			var write = value as Action<System.IO.TextWriter>;
			if (write != null) {
				write (writer);
				return;
			}

			//NOTE: a more sophisticated implementation would write safe and pre-escaped values directly to the
			//instead of double-escaping. See System.Web.IHtmlString in ASP.NET 4.0 for an example of this.
			writer.Write(System.Net.WebUtility.HtmlEncode (value.ToString ()));
		}

		// This method is REQUIRED, but you may choose to implement it differently
		//
		/// <summary>
		/// Conditionally writes an attribute to the template output.
		/// </summary>
		/// <param name="name">The name of the attribute.</param>
		/// <param name="prefix">The prefix of the attribute.</param>
		/// <param name="suffix">The suffix of the attribute.</param>
		/// <param name="values">Attribute values, each specifying a prefix, value and whether it's a literal.</param>
		protected void WriteAttribute (string name, string prefix, string suffix, params Tuple<string,object,bool>[] values)
		{
			WriteAttributeTo (__razor_writer, name, prefix, suffix, values);
		}

		// This method is REQUIRED if the template contains any Razor helpers, but you may choose to implement it differently
		//
		/// <summary>
		/// Conditionally writes an attribute to a TextWriter.
		/// </summary>
		/// <param name="writer">The TextWriter to which to write the attribute.</param>
		/// <param name="name">The name of the attribute.</param>
		/// <param name="prefix">The prefix of the attribute.</param>
		/// <param name="suffix">The suffix of the attribute.</param>
		/// <param name="values">Attribute values, each specifying a prefix, value and whether it's a literal.</param>
		///<remarks>Used by Razor helpers to write attributes.</remarks>
		protected static void WriteAttributeTo (System.IO.TextWriter writer, string name, string prefix, string suffix, params Tuple<string,object,bool>[] values)
		{
			// this is based on System.Web.WebPages.WebPageExecutingBase
			// Copyright (c) Microsoft Open Technologies, Inc.
			// Licensed under the Apache License, Version 2.0
			if (values.Length == 0) {
				// Explicitly empty attribute, so write the prefix and suffix
				writer.Write (prefix);
				writer.Write (suffix);
				return;
			}

			bool first = true;
			bool wroteSomething = false;

			for (int i = 0; i < values.Length; i++) {
				Tuple<string,object,bool> attrVal = values [i];
				string attPrefix = attrVal.Item1;
				object value = attrVal.Item2;
				bool isLiteral = attrVal.Item3;

				if (value == null) {
					// Nothing to write
					continue;
				}

				// The special cases here are that the value we're writing might already be a string, or that the
				// value might be a bool. If the value is the bool 'true' we want to write the attribute name instead
				// of the string 'true'. If the value is the bool 'false' we don't want to write anything.
				//
				// Otherwise the value is another object (perhaps an IHtmlString), and we'll ask it to format itself.
				string stringValue;
				bool? boolValue = value as bool?;
				if (boolValue == true) {
					stringValue = name;
				} else if (boolValue == false) {
					continue;
				} else {
					stringValue = value as string;
				}

				if (first) {
					writer.Write (prefix);
					first = false;
				} else {
					writer.Write (attPrefix);
				}

				if (isLiteral) {
					writer.Write (stringValue ?? value);
				} else {
					WriteTo (writer, stringValue ?? value);
				}
				wroteSomething = true;
			}
			if (wroteSomething) {
				writer.Write (suffix);
			}
		}
		// This method is REQUIRED. The generated Razor subclass will override it with the generated code.
		//
		///<summary>Executes the template, writing output to the Write and WriteLiteral methods.</summary>.
		///<remarks>Not intended to be called directly. Call the Generate method instead.</remarks>
		public abstract void Execute ();

}
}
#pragma warning restore 1591
