using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;
using System.Xml;

namespace Capa_Entidades.Clases
{

    /// <summary>
    /// Clase Factura, se encarga de elaborar el PDF y XML que seran enviados por correo
    /// </summary>
    public class Factura
    {

        /// <summary> _UsuarioCliente </summary>
        /// <value> Usuario cliente </value>
        public Usuario _UsuarioCliente = null;

        /// <summary> _PagoUsuarioCliente </summary>
        /// <value> Pago que contiene el pedido del cliente </value>
        public Pago _PagoUsuarioCliente = null;

        /// <summary> _UsuarioComercio </summary>
        /// <value> Usuario Comercio </value>
        public Usuario _UsuarioComercio = null;


        /// <summary>
        /// Constructor de clase, sin recibir parametros
        /// </summary>
        public Factura()
        {
            this._UsuarioCliente = null;
            this._PagoUsuarioCliente = null;
            this._UsuarioComercio = null;
        }

        #region METODOS
        /// <summary>
        /// Metodo AsignaCliente, asigna el Cliente
        /// </summary>
        /// <returns>void</returns>
        public void AsignaCliente(Usuario pCliente)
        {
            this._UsuarioCliente = pCliente;
        }

        /// <summary>
        /// Metodo AsignaCliente, asigna el Pago
        /// </summary>
        /// <returns>void</returns>
        public void AsignaPagoCliente(Pago pPago)
        {
            this._PagoUsuarioCliente = pPago;
        }

        /// <summary>
        /// Metodo AsignaCliente, asigna el Comercio
        /// </summary>
        /// <returns>void</returns>
        public  void AsignaComercio(Usuario pComercio)
        {
            this._UsuarioComercio = pComercio;
        }





        /// <summary>
        /// Metodo CalculaMonto_Total, calcula el total de la factura
        /// </summary>
        /// <returns>double</returns>
        public double CalculaMonto_Total()
        {
            return Calcula_SubTotal() + Calcula_IVA();
        }

        /// <summary>
        /// Metodo CalculaMonto_Total_SoloConIVA, calcula el total de la factura
        /// </summary>
        /// <returns>double</returns>
        public double CalculaMonto_Total_SoloConIVA()
        {
            return Calcula_SubTotal_Gravado() + Calcula_IVA();
        }

        /// <summary>
        /// Metodo CalculaMonto_Total_Dolares, calcula el total de la factura en dolares
        /// </summary>
        /// <returns>double</returns>
        public double CalculaMonto_Total_Dolares()
        {
            return (Calcula_SubTotal() + Calcula_IVA())/_PagoUsuarioCliente._Moneda.ValorCompra;
        }

        /// <summary>
        /// Metodo CalculaMonto_Total_SinEnvio, calcula el total de la factura sin el envio
        /// </summary>
        /// <returns>double</returns>
        public double CalculaMonto_Total_SinEnvio()
        {
            return Calcula_SubTotal_Gravado()+Calcula_IVA();
        }

        /// <summary>
        /// Metodo CalculaMonto_Cupones, calcula el total de dinero
        /// por los cupones
        /// </summary>
        /// <returns>double</returns>
        public double CalculaMonto_Cupones()
        {
            double sumatoria = 0.0;
            foreach (Articulo item in _PagoUsuarioCliente._Pedido._ListaArticulosComprados)
            {
                if(item is Articulo_Cupon)
                sumatoria += item.Precio;
            }
            return sumatoria;
        }

        /// <summary>
        /// Metodo CalculaMonto_Productos, calcula el total de dinero
        /// por los productos
        /// </summary>
        /// <returns>double</returns>
        public double CalculaMonto_Productos()
        {
            double sumatoria = 0.0;
            foreach (Articulo item in _PagoUsuarioCliente._Pedido._ListaArticulosComprados)
            {
                if (item is Articulo_Producto)
                    sumatoria += item.Precio;
            }
            return sumatoria;
        }

        /// <summary>
        /// Metodo Calcula_IVA, calcula el IVA
        /// </summary>
        /// <returns>double</returns>
        public double Calcula_IVA()
        {
            return Calcula_SubTotal() * .13;
        }

        /// <summary>
        /// Metodo Calcula_SubTotal, calcula monto sin IVA
        /// </summary>
        /// <returns>double</returns>
        public double Calcula_SubTotal()
        {
            double sumatoria = 0.0;
            foreach(Articulo item in _PagoUsuarioCliente._Pedido._ListaArticulosComprados)
            {
                sumatoria += item.Precio;
            }
            return sumatoria + Calcula_Envio();
        }

        public double Calcula_SubTotal_Gravado()
        {
            double sumatoria = 0.0;
            foreach (Articulo item in _PagoUsuarioCliente._Pedido._ListaArticulosComprados)
            {
                sumatoria += item.Precio;
            }
            return sumatoria ;
        }

        /// <summary>
        /// Metodo Calcula_Envio, calcula coste del envio
        /// </summary>
        /// <returns>double</returns>
        public double Calcula_Envio()
        {
            return _PagoUsuarioCliente.CostoExpressColones();
        }





        /// <summary>
        /// Metodo que genera el XML de Factura
        /// </summary>
        /// <returns>string</returns>
        public string ObtenerXML()
        {
            XmlDocument documento = new XmlDocument();
            XmlDeclaration dec = documento.CreateXmlDeclaration("1.0", null, null);
            documento.AppendChild(dec);

            XmlElement raiz = documento.CreateElement("raiz");
            XmlElement facturaElectronica = documento.CreateElement("facturaElectronica");

            XmlElement tributario = documento.CreateElement("tributario");

            XmlElement identificacion = documento.CreateElement("identificacion");
            identificacion.InnerText = _UsuarioComercio.Identificacion.ToString();
            tributario.AppendChild(identificacion);

            XmlElement Nombre = documento.CreateElement("nombre");
            Nombre.InnerText = _UsuarioComercio.Nombre;
            tributario.AppendChild(Nombre);

            XmlElement direccion = documento.CreateElement("direccion");
            direccion.InnerText = _UsuarioComercio._Direccion.DescripcionUbicacion;
            tributario.AppendChild(direccion);

            XmlElement correoElectronico = documento.CreateElement("correoElectronico");
            correoElectronico.InnerText = _UsuarioComercio.CorreoElectronico;
            tributario.AppendChild(correoElectronico);

            facturaElectronica.AppendChild(tributario);

            //NUMERACION CONSECUTIVA ????

            //CLAVE NUMERICA ????

            XmlElement fechaEmision = documento.CreateElement("fechaEmision");
            fechaEmision.InnerText = _PagoUsuarioCliente.FechaPago.ToString("dd/MM/yy hh:mm");
            facturaElectronica.AppendChild(fechaEmision);

            XmlElement condicionVenta = documento.CreateElement("condicionVenta");
            condicionVenta.InnerText = "CONTADO";
            facturaElectronica.AppendChild(condicionVenta);

            XmlElement medioPago = documento.CreateElement("medioPago");
            medioPago.InnerText = "TARJETA";
            facturaElectronica.AppendChild(medioPago);

            XmlElement mercancia = documento.CreateElement("mercancia");
            foreach(Articulo item in _PagoUsuarioCliente._Pedido._ListaArticulosComprados)
            {
                XmlElement producto = documento.CreateElement("producto");

                XmlElement codigo = documento.CreateElement("codigo");
                codigo.InnerText = item.Identificacion;
                producto.AppendChild(codigo);

                XmlElement nombre = documento.CreateElement("nombre");
                nombre.InnerText = item.Nombre;
                producto.AppendChild(nombre);

                XmlElement descripcion = documento.CreateElement("descripcion");
                descripcion.InnerText = item.Descripcion;
                producto.AppendChild(descripcion);

                XmlElement precio = documento.CreateElement("precio");
                precio.InnerText = "₡" + item.Precio.ToString("#,###,###.00");
                producto.AppendChild(precio);

                mercancia.AppendChild(producto);
            }
            facturaElectronica.AppendChild(mercancia);

            XmlElement descuento = documento.CreateElement("descuento");
            descuento.InnerText = "₡ 0.00";
            facturaElectronica.AppendChild(descuento);

            XmlElement subtotal = documento.CreateElement("subtotal");
            subtotal.InnerText = "₡ " + Calcula_SubTotal_Gravado().ToString("#,###,###.00");
            facturaElectronica.AppendChild(subtotal);

            XmlElement impuesto = documento.CreateElement("impuesto");
            impuesto.InnerText = "13%" ;
            facturaElectronica.AppendChild(impuesto);

            XmlElement serviciosPrestados = documento.CreateElement("serviciosPrestados");
            serviciosPrestados.InnerText = "₡ " + Calcula_Envio().ToString("#,###,###.00");
            facturaElectronica.AppendChild(serviciosPrestados);

            XmlElement valorMercancias = documento.CreateElement("valorMercancias");
            valorMercancias.InnerText = "₡ " + (CalculaMonto_Cupones() + CalculaMonto_Productos()).ToString("#,###,###.00");
            facturaElectronica.AppendChild(valorMercancias);

            XmlElement precioNeto = documento.CreateElement("precioNeto");
            precioNeto.InnerText = "₡ " + Calcula_SubTotal().ToString("#,###,###.00");
            facturaElectronica.AppendChild(precioNeto);

            XmlElement impuestoVentas = documento.CreateElement("impuestoVentas");
            impuestoVentas.InnerText = "₡ " + Calcula_IVA().ToString("#,###,###.00");
            facturaElectronica.AppendChild(impuestoVentas);

            XmlElement valorTotal = documento.CreateElement("valorTotal");
            valorTotal.InnerText = "₡ " + CalculaMonto_Total().ToString("#,###,###.00");
            facturaElectronica.AppendChild(valorTotal);

            raiz.AppendChild(facturaElectronica);
            documento.AppendChild(raiz);
            return documento.InnerXml;
        }


        /// <summary>
        /// Metodo que genera el PDF de Factura
        /// </summary>
        /// <returns>void</returns>
        public void ObtenerPDF()
        {
            List<int> Repeticiones = new List<int>();

            //CREA EL DOCUMENTO
            Document doc = new Document(iTextSharp.text.PageSize.LETTER);
            //    Document doc = new Document(iTextSharp.text.PageSize.A4.Rotate());

            //TIPOS DE LETRA QUE VAMOS USAR
            BaseFont arial = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            iTextSharp.text.Font f_15_bold = new iTextSharp.text.Font(arial, 13, iTextSharp.text.Font.BOLD);
            iTextSharp.text.Font f_12_normal = new iTextSharp.text.Font(arial, 12, iTextSharp.text.Font.NORMAL);
            iTextSharp.text.Font f_12_normal_ColorRed = new iTextSharp.text.Font(arial, 12, iTextSharp.text.Font.NORMAL, BaseColor.RED);
            iTextSharp.text.Font f_12_normal_ColorWhite = new iTextSharp.text.Font(arial, 12, iTextSharp.text.Font.NORMAL, BaseColor.WHITE);
            iTextSharp.text.Font f_12_bold = new iTextSharp.text.Font(arial, 12, iTextSharp.text.Font.BOLD);


            Random rnd = new Random();
            int numeroRnd = rnd.Next(1762, 10000);
            //RUTA DONDE SE VA GUARDAR EL DOCUMENTO PDF
            FileStream os = new FileStream(@"c:\temp\FacturaCompra.pdf", FileMode.Create);

            using (os)
            {
                PdfWriter.GetInstance(doc, os);//DEFINIMOS QUE DOCUMENTO VAMOS USAR
                doc.Open();// LO ABRIMOS

                //E:\VisualProyectos\901100632_JohnPaulAlfaroCarballo\Proyecto_CodigoFuente\CAPAS\Capa_Vista\imagen
                AgregaImagenPDF(doc, @"..\..\imagen\pngegg.png");

                #region INFORMACION DE COMPANNIA 
                //INFORMACION DE LA COMAPNNIA
                PdfPTable table1 = new PdfPTable(1);
                float[] width = new float[] { 40f, 60f };
                PdfPCell cel1 = new PdfPCell(new Phrase(_UsuarioComercio.Nombre, f_15_bold));
                PdfPCell cel2 = new PdfPCell(new Phrase(_UsuarioComercio.Identificacion.ToString(), f_15_bold));
                PdfPCell cel3 = new PdfPCell(new Phrase(_UsuarioComercio._Direccion.DescripcionUbicacion, f_12_normal));
                PdfPCell cel4 = new PdfPCell(new Phrase("Correo Electronico:"+_UsuarioComercio.CorreoElectronico
                    +" \nTelefono :"+_UsuarioComercio.NumeroTelefono+"\n", f_12_normal));

                //DEFINE EL ESTILO CON EL CUAL SE DESPLEGARA
                cel1.Border = iTextSharp.text.Rectangle.NO_BORDER;
                cel2.Border = iTextSharp.text.Rectangle.NO_BORDER;
                cel3.Border = iTextSharp.text.Rectangle.NO_BORDER;
                cel4.Border = iTextSharp.text.Rectangle.NO_BORDER;
                //DEFINE LA POSICION DONDE SE DESPLEGARA
                cel1.HorizontalAlignment = Element.ALIGN_JUSTIFIED;
                cel2.HorizontalAlignment = Element.ALIGN_JUSTIFIED;
                cel3.HorizontalAlignment = Element.ALIGN_JUSTIFIED;
                cel4.HorizontalAlignment = Element.ALIGN_JUSTIFIED;
                //DEFINE ESTILO Y POSISICION DONDE COLOCAREMOS NUESTRA TABLA 1
                table1.WidthPercentage = 70;// ancho de la caja
                table1.HorizontalAlignment = Element.ALIGN_LEFT;
                table1.AddCell(cel1);
                table1.AddCell(cel2);
                table1.AddCell(cel3);
                table1.AddCell(cel4);

                table1.SpacingAfter = 15;//espacio hacia la siguiente estructura
                table1.SpacingBefore = 20;

                // WriteWaterMark(doc, @"..\..\imagen\final.png");
                doc.Add(table1);//se agrega la tabla al documento
                #endregion


                #region INFORMACION DE CLIENTE
                table1 = new PdfPTable(1);
                cel4 = new PdfPCell(new Phrase("INFORMACION DEL CLIENTE", f_12_bold));
                cel1 = new PdfPCell(new Phrase("Identificacion: "+_UsuarioCliente.Identificacion.ToString(), f_12_normal));
                cel2 = new PdfPCell(new Phrase("Nombre Completo: "+ _UsuarioCliente.Nombre+" "+(_UsuarioCliente as Usuario_Cliente).Apellido, f_12_normal));
                cel3 = new PdfPCell(new Phrase("Numero de telefono: "+_UsuarioCliente.NumeroTelefono, f_12_normal));
                PdfPCell cel7 = new PdfPCell(new Phrase("Correo electronico: " + _UsuarioCliente.CorreoElectronico, f_12_normal));
                PdfPCell cel8 = new PdfPCell(new Phrase("Direccion fisica: " + _UsuarioCliente._Direccion.DescripcionUbicacion, f_12_normal));


                cel1.HorizontalAlignment = Element.ALIGN_JUSTIFIED;
                cel2.HorizontalAlignment = Element.ALIGN_JUSTIFIED;
                cel3.HorizontalAlignment = Element.ALIGN_JUSTIFIED;
                cel4.HorizontalAlignment = Element.ALIGN_TOP;
                cel7.HorizontalAlignment = Element.ALIGN_JUSTIFIED;
                cel8.HorizontalAlignment = Element.ALIGN_JUSTIFIED;

                cel1.Border = iTextSharp.text.Rectangle.NO_BORDER;
                cel2.Border = iTextSharp.text.Rectangle.NO_BORDER;
                cel3.Border = iTextSharp.text.Rectangle.NO_BORDER;
                cel7.Border = iTextSharp.text.Rectangle.NO_BORDER;
                cel8.Border = iTextSharp.text.Rectangle.NO_BORDER;
                //     cel4.Border = iTextSharp.text.Rectangle.NO_BORDER;

                cel4.BackgroundColor = BaseColor.LIGHT_GRAY;


                table1.AddCell(cel4);
                table1.AddCell(cel1);
                table1.AddCell(cel2);
                table1.AddCell(cel3);
                table1.AddCell(cel7);
                table1.AddCell(cel8);

                table1.SpacingAfter = 20;
                //  table1.SpacingBefore = 10;
                table1.WidthPercentage = 40;

                PdfPTable table2 = new PdfPTable(1);
                table2.AddCell(table1);
                table2.HorizontalAlignment = Element.ALIGN_RIGHT;
                //  table1.WidthPercentage = 40;
                doc.Add(table2);
                #endregion


                #region INFORMACION DE LA FACTURA

                iTextSharp.text.Paragraph parrafo = new iTextSharp.text.Paragraph(new Phrase("Fecha de venta: " + DateTime.Now.ToString() + "\n", f_12_normal));
                //   parrafo.Add(new Phrase("Fecha de venta: " + DateTime.Now.Date.ToString() + "\n", f_12_normal));
                parrafo.Add(new Phrase("Numero de factura N°"+ numeroRnd.ToString()+ "", f_15_bold));
                parrafo.Alignment = Element.ALIGN_JUSTIFIED;
                doc.Add(parrafo);

                #endregion


                #region LISTA DE PRODUCTOS
                table1 = new PdfPTable(5);//5 NUMERO DE LAS COLUMNAS QUE SE VAN UTILIZAR

                //COLUMNAS DE LA TABLA
                cel1 = new PdfPCell(new Phrase("CODIGO", f_12_bold));
                cel1.HorizontalAlignment = Element.ALIGN_LEFT;
                cel1.FixedHeight = 20;
                cel1.BackgroundColor = BaseColor.LIGHT_GRAY;
                table1.AddCell(cel1);
                cel1 = new PdfPCell(new Phrase("NOMBRE", f_12_bold));
                cel1.HorizontalAlignment = Element.ALIGN_LEFT;
                cel1.FixedHeight = 20;
                cel1.BackgroundColor = BaseColor.LIGHT_GRAY;
                table1.AddCell(cel1);
                cel1 = new PdfPCell(new Phrase("CANT", f_12_bold));
                cel1.HorizontalAlignment = Element.ALIGN_LEFT;
                cel1.FixedHeight = 20;
                cel1.BackgroundColor = BaseColor.LIGHT_GRAY;
                table1.AddCell(cel1);
                cel1 = new PdfPCell(new Phrase("PRC UND", f_12_bold));
                cel1.HorizontalAlignment = Element.ALIGN_LEFT;
                cel1.FixedHeight = 20;
                cel1.BackgroundColor = BaseColor.LIGHT_GRAY;
                table1.AddCell(cel1);
                cel1 = new PdfPCell(new Phrase("PRC TT", f_12_bold));
                cel1.HorizontalAlignment = Element.ALIGN_LEFT;
                cel1.FixedHeight = 20;
                cel1.BackgroundColor = BaseColor.LIGHT_GRAY;
                table1.AddCell(cel1);



                //CALCULA LA CANTIDAD DE ARTICULOS POR CADA UNO, FUERON COMPRADOS
                int repeticiones = 0;
                List<Articulo> art = new List<Articulo>();
                foreach (Articulo item in _PagoUsuarioCliente._Pedido._ListaArticulosComprados)
                {
                    foreach (Articulo itemAux in _PagoUsuarioCliente._Pedido._ListaArticulosComprados)
                    {
                        if(item.Identificacion == itemAux.Identificacion)
                        {
                            repeticiones++;
                        }
                    }
                    Articulo a = item;
                    a.Cantidad = repeticiones;
                    art.Add(a);
                    repeticiones = 0;
                }

                


                int x = 0;
                foreach (Articulo item in art.Distinct())
                {

                    cel1 = new PdfPCell(new Phrase(item.Identificacion.ToString()));
                    cel1.HorizontalAlignment = Element.ALIGN_LEFT;
                    cel1.FixedHeight = 20;
                    table1.AddCell(cel1);

                    cel1 = new PdfPCell(new Phrase(item.Nombre));
                    cel1.HorizontalAlignment = Element.ALIGN_LEFT;
                    cel1.FixedHeight = 20;
                    table1.AddCell(cel1);

                    cel1 = new PdfPCell(new Phrase(item.Cantidad.ToString()));
                    cel1.HorizontalAlignment = Element.ALIGN_CENTER;
                    cel1.FixedHeight = 20;
                    table1.AddCell(cel1);

                    cel1 = new PdfPCell(new Phrase("₡" + item.Precio.ToString("#,###,###.00") ));
                    cel1.HorizontalAlignment = Element.ALIGN_LEFT;
                    cel1.FixedHeight = 20;
                    table1.AddCell(cel1);

                    cel1 = new PdfPCell(new Phrase("₡"+(item.Precio * item.Cantidad).ToString("#,###,###.00") ));
                    cel1.HorizontalAlignment = Element.ALIGN_LEFT;
                    cel1.FixedHeight = 20;
                    table1.AddCell(cel1);

                    x++;
                }

                table1.WidthPercentage = 100;
                width = new float[] { 100f, 400f, 100f, 115, 125 };
                table1.SetWidths(width);
                table1.SpacingBefore = 20;
                doc.Add(table1);

                //TOTAL
                table1 = new PdfPTable(2);
                cel1 = new PdfPCell(new Phrase("SubTotal Gravado: ", f_12_bold));
                cel1.BackgroundColor = BaseColor.LIGHT_GRAY;
                cel2 = new PdfPCell(new Phrase("₡"+Calcula_SubTotal_Gravado().ToString("#,###,###.00"), f_12_normal));

                cel7 = new PdfPCell(new Phrase("Descuento Gravado: ", f_12_bold));
                cel7.BackgroundColor = BaseColor.LIGHT_GRAY;
                cel8 = new PdfPCell(new Phrase("₡0.00"  , f_12_normal));

                cel3 = new PdfPCell(new Phrase("Impuestos: ", f_12_bold));
                cel3.BackgroundColor = BaseColor.LIGHT_GRAY;
                cel4 = new PdfPCell(new Phrase("₡" + Calcula_IVA().ToString("#,###,###.00"), f_12_normal));

                PdfPCell cel9 = new PdfPCell(new Phrase("Total: ", f_12_bold));
                cel9.BackgroundColor = BaseColor.LIGHT_GRAY;
                PdfPCell cel10 = new PdfPCell(new Phrase("₡" + CalculaMonto_Total_SinEnvio().ToString("#,###,###.00"), f_12_normal));

                PdfPCell cel11 = new PdfPCell(new Phrase("Otros: ", f_12_bold));
                cel11.BackgroundColor = BaseColor.LIGHT_GRAY;
                PdfPCell cel12 = new PdfPCell(new Phrase("₡" + Calcula_Envio().ToString("#,###,###.00"), f_12_normal));

                PdfPCell cel5 = new PdfPCell(new Phrase("Total a Pagar Colones: ", f_12_bold));
                cel5.BackgroundColor = BaseColor.LIGHT_GRAY;
                PdfPCell cel6 = new PdfPCell(new Phrase("₡" + CalculaMonto_Total().ToString("#,###,###.00"), f_12_normal_ColorRed));

                PdfPCell cel13 = new PdfPCell(new Phrase("Total a Pagar Dolares: ", f_12_bold));
                cel13.BackgroundColor = BaseColor.LIGHT_GRAY;
                PdfPCell cel14 = new PdfPCell(new Phrase( CalculaMonto_Total_Dolares().ToString("#,###,###.00"), f_12_normal_ColorRed));

                table1.WidthPercentage = 100;
                width = new float[] { 165, 50 };

                cel1.HorizontalAlignment = Element.ALIGN_RIGHT;
                cel1.FixedHeight = 20;
                cel3.HorizontalAlignment = Element.ALIGN_RIGHT;
                cel3.FixedHeight = 20;
                cel5.HorizontalAlignment = Element.ALIGN_RIGHT;
                cel5.FixedHeight = 20;
                cel7.HorizontalAlignment = Element.ALIGN_RIGHT;
                cel7.FixedHeight = 20;
                cel9.HorizontalAlignment = Element.ALIGN_RIGHT;
                cel9.FixedHeight = 20;
                cel11.HorizontalAlignment = Element.ALIGN_RIGHT;
                cel11.FixedHeight = 20;
                cel13.HorizontalAlignment = Element.ALIGN_RIGHT;
                cel13.FixedHeight = 20;

                cel2.HorizontalAlignment = Element.ALIGN_LEFT;
                cel4.HorizontalAlignment = Element.ALIGN_LEFT;
                cel6.HorizontalAlignment = Element.ALIGN_LEFT;
                cel8.HorizontalAlignment = Element.ALIGN_LEFT;
                cel10.HorizontalAlignment = Element.ALIGN_LEFT;
                cel12.HorizontalAlignment = Element.ALIGN_LEFT;
                cel6.HorizontalAlignment = Element.ALIGN_LEFT;
                cel14.HorizontalAlignment = Element.ALIGN_LEFT;

                table1.SetWidths(width);
                table1.AddCell(cel1);
                table1.AddCell(cel2);

                table1.AddCell(cel7);
                table1.AddCell(cel8);
                table1.AddCell(cel3);
                table1.AddCell(cel4);
                table1.AddCell(cel9);
                table1.AddCell(cel10);
                table1.AddCell(cel11);
                table1.AddCell(cel12);
                table1.AddCell(cel5);
                table1.AddCell(cel6);
                table1.AddCell(cel13);
                table1.AddCell(cel14);

                table1.SpacingAfter = 10;
                doc.Add(table1);
                #endregion



                string xmlGenerado = ObtenerXML();
                string xmlCifrado = Utilitarios.ComputeSha256Hash(xmlGenerado);
                parrafo = new iTextSharp.text.Paragraph(new Phrase("Codigo de XML enviado cifrado:\n " + xmlCifrado+" \n", f_12_normal));
                parrafo.Add(new Phrase("\nAutorizada mediante resolución Nº DGT - R - 48 - 2016 del 7 de octubre de 2016\n", f_12_normal));
                parrafo.Alignment = Element.ALIGN_JUSTIFIED;
                doc.Add(parrafo);

                parrafo = new iTextSharp.text.Paragraph(new Phrase(this.ObtenerXML(), f_12_normal));
                doc.NewPage();
                doc.Add(parrafo);

                doc.Close();//CERRAMOS EL DOCUMENTO
            }
        }
         

        /// <summary>
        /// Metodo que genera el PDF de Factura, y lo guarda en la ruta especificada por el usuario
        /// </summary>
        /// <returns>void</returns>
        public void ObtenerPDF_GuardadoEnRutaSeleccionada(string pRuta)
        {
            List<int> Repeticiones = new List<int>();

            //CREA EL DOCUMENTO
            Document doc = new Document(iTextSharp.text.PageSize.LETTER);
            //    Document doc = new Document(iTextSharp.text.PageSize.A4.Rotate());

            //TIPOS DE LETRA QUE VAMOS USAR
            BaseFont arial = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            iTextSharp.text.Font f_15_bold = new iTextSharp.text.Font(arial, 13, iTextSharp.text.Font.BOLD);
            iTextSharp.text.Font f_12_normal = new iTextSharp.text.Font(arial, 12, iTextSharp.text.Font.NORMAL);
            iTextSharp.text.Font f_12_normal_ColorRed = new iTextSharp.text.Font(arial, 12, iTextSharp.text.Font.NORMAL, BaseColor.RED);
            iTextSharp.text.Font f_12_normal_ColorWhite = new iTextSharp.text.Font(arial, 12, iTextSharp.text.Font.NORMAL, BaseColor.WHITE);
            iTextSharp.text.Font f_12_bold = new iTextSharp.text.Font(arial, 12, iTextSharp.text.Font.BOLD);


            Random rnd = new Random();
            int numeroRnd = rnd.Next(1762, 10000);
            //RUTA DONDE SE VA GUARDAR EL DOCUMENTO PDF
            FileStream os = new FileStream(pRuta, FileMode.Create);

            using (os)
            {
                PdfWriter.GetInstance(doc, os);//DEFINIMOS QUE DOCUMENTO VAMOS USAR
                doc.Open();// LO ABRIMOS

                AgregaImagenPDF(doc, @"..\..\imagen\pngegg.png");

                #region INFORMACION DE COMPANNIA 
                //INFORMACION DE LA COMAPNNIA
                PdfPTable table1 = new PdfPTable(1);
                float[] width = new float[] { 40f, 60f };
                PdfPCell cel1 = new PdfPCell(new Phrase(_UsuarioComercio.Nombre, f_15_bold));
                PdfPCell cel2 = new PdfPCell(new Phrase(_UsuarioComercio.Identificacion.ToString(), f_15_bold));
                PdfPCell cel3 = new PdfPCell(new Phrase(_UsuarioComercio._Direccion.DescripcionUbicacion, f_12_normal));
                PdfPCell cel4 = new PdfPCell(new Phrase("Correo Electronico:" + _UsuarioComercio.CorreoElectronico
                    + " \nTelefono :" + _UsuarioComercio.NumeroTelefono + "\n", f_12_normal));

                //DEFINE EL ESTILO CON EL CUAL SE DESPLEGARA
                cel1.Border = iTextSharp.text.Rectangle.NO_BORDER;
                cel2.Border = iTextSharp.text.Rectangle.NO_BORDER;
                cel3.Border = iTextSharp.text.Rectangle.NO_BORDER;
                cel4.Border = iTextSharp.text.Rectangle.NO_BORDER;
                //DEFINE LA POSICION DONDE SE DESPLEGARA
                cel1.HorizontalAlignment = Element.ALIGN_JUSTIFIED;
                cel2.HorizontalAlignment = Element.ALIGN_JUSTIFIED;
                cel3.HorizontalAlignment = Element.ALIGN_JUSTIFIED;
                cel4.HorizontalAlignment = Element.ALIGN_JUSTIFIED;
                //DEFINE ESTILO Y POSISICION DONDE COLOCAREMOS NUESTRA TABLA 1
                table1.WidthPercentage = 70;// ancho de la caja
                table1.HorizontalAlignment = Element.ALIGN_LEFT;
                table1.AddCell(cel1);
                table1.AddCell(cel2);
                table1.AddCell(cel3);
                table1.AddCell(cel4);

                table1.SpacingAfter = 15;//espacio hacia la siguiente estructura
                table1.SpacingBefore = 20;

                // WriteWaterMark(doc, @"..\..\imagen\final.png");
                doc.Add(table1);//se agrega la tabla al documento
                #endregion


                #region INFORMACION DE CLIENTE
                table1 = new PdfPTable(1);
                cel4 = new PdfPCell(new Phrase("INFORMACION DEL CLIENTE", f_12_bold));
                cel1 = new PdfPCell(new Phrase("Identificacion: " + _UsuarioCliente.Identificacion.ToString(), f_12_normal));
                cel2 = new PdfPCell(new Phrase("Nombre Completo: " + _UsuarioCliente.Nombre + " " + (_UsuarioCliente as Usuario_Cliente).Apellido, f_12_normal));
                cel3 = new PdfPCell(new Phrase("Numero de telefono: " + _UsuarioCliente.NumeroTelefono, f_12_normal));
                PdfPCell cel7 = new PdfPCell(new Phrase("Correo electronico: " + _UsuarioCliente.CorreoElectronico, f_12_normal));
                PdfPCell cel8 = new PdfPCell(new Phrase("Direccion fisica: " + _UsuarioCliente._Direccion.DescripcionUbicacion, f_12_normal));


                cel1.HorizontalAlignment = Element.ALIGN_JUSTIFIED;
                cel2.HorizontalAlignment = Element.ALIGN_JUSTIFIED;
                cel3.HorizontalAlignment = Element.ALIGN_JUSTIFIED;
                cel4.HorizontalAlignment = Element.ALIGN_TOP;
                cel7.HorizontalAlignment = Element.ALIGN_JUSTIFIED;
                cel8.HorizontalAlignment = Element.ALIGN_JUSTIFIED;

                cel1.Border = iTextSharp.text.Rectangle.NO_BORDER;
                cel2.Border = iTextSharp.text.Rectangle.NO_BORDER;
                cel3.Border = iTextSharp.text.Rectangle.NO_BORDER;
                cel7.Border = iTextSharp.text.Rectangle.NO_BORDER;
                cel8.Border = iTextSharp.text.Rectangle.NO_BORDER;
                //     cel4.Border = iTextSharp.text.Rectangle.NO_BORDER;

                cel4.BackgroundColor = BaseColor.LIGHT_GRAY;


                table1.AddCell(cel4);
                table1.AddCell(cel1);
                table1.AddCell(cel2);
                table1.AddCell(cel3);
                table1.AddCell(cel7);
                table1.AddCell(cel8);

                table1.SpacingAfter = 20;
                //  table1.SpacingBefore = 10;
                table1.WidthPercentage = 40;

                PdfPTable table2 = new PdfPTable(1);
                table2.AddCell(table1);
                table2.HorizontalAlignment = Element.ALIGN_RIGHT;
                //  table1.WidthPercentage = 40;
                doc.Add(table2);
                #endregion


                #region INFORMACION DE LA FACTURA

                iTextSharp.text.Paragraph parrafo = new iTextSharp.text.Paragraph(new Phrase("Fecha de venta: " + DateTime.Now.ToString() + "\n", f_12_normal));
                //   parrafo.Add(new Phrase("Fecha de venta: " + DateTime.Now.Date.ToString() + "\n", f_12_normal));
                parrafo.Add(new Phrase("Numero de factura N°" + numeroRnd.ToString() + "", f_15_bold));
                parrafo.Alignment = Element.ALIGN_JUSTIFIED;
                doc.Add(parrafo);

                #endregion


                #region LISTA DE PRODUCTOS
                table1 = new PdfPTable(5);//5 NUMERO DE LAS COLUMNAS QUE SE VAN UTILIZAR

                //COLUMNAS DE LA TABLA
                cel1 = new PdfPCell(new Phrase("CODIGO", f_12_bold));
                cel1.HorizontalAlignment = Element.ALIGN_LEFT;
                cel1.FixedHeight = 20;
                cel1.BackgroundColor = BaseColor.LIGHT_GRAY;
                table1.AddCell(cel1);
                cel1 = new PdfPCell(new Phrase("NOMBRE", f_12_bold));
                cel1.HorizontalAlignment = Element.ALIGN_LEFT;
                cel1.FixedHeight = 20;
                cel1.BackgroundColor = BaseColor.LIGHT_GRAY;
                table1.AddCell(cel1);
                cel1 = new PdfPCell(new Phrase("CANT", f_12_bold));
                cel1.HorizontalAlignment = Element.ALIGN_LEFT;
                cel1.FixedHeight = 20;
                cel1.BackgroundColor = BaseColor.LIGHT_GRAY;
                table1.AddCell(cel1);
                cel1 = new PdfPCell(new Phrase("PRC UND", f_12_bold));
                cel1.HorizontalAlignment = Element.ALIGN_LEFT;
                cel1.FixedHeight = 20;
                cel1.BackgroundColor = BaseColor.LIGHT_GRAY;
                table1.AddCell(cel1);
                cel1 = new PdfPCell(new Phrase("PRC TT", f_12_bold));
                cel1.HorizontalAlignment = Element.ALIGN_LEFT;
                cel1.FixedHeight = 20;
                cel1.BackgroundColor = BaseColor.LIGHT_GRAY;
                table1.AddCell(cel1);



                //CALCULA LA CANTIDAD DE ARTICULOS POR CADA UNO, FUERON COMPRADOS
                int repeticiones = 0;
                List<Articulo> art = new List<Articulo>();
                foreach (Articulo item in _PagoUsuarioCliente._Pedido._ListaArticulosComprados)
                {
                    foreach (Articulo itemAux in _PagoUsuarioCliente._Pedido._ListaArticulosComprados)
                    {
                        if (item.Identificacion == itemAux.Identificacion)
                        {
                            repeticiones++;
                        }
                    }
                    Articulo a = item;
                    a.Cantidad = repeticiones;
                    art.Add(a);
                    repeticiones = 0;
                }




                int x = 0;
                foreach (Articulo item in art.Distinct())
                {

                    cel1 = new PdfPCell(new Phrase(item.Identificacion.ToString()));
                    cel1.HorizontalAlignment = Element.ALIGN_LEFT;
                    cel1.FixedHeight = 20;
                    table1.AddCell(cel1);

                    cel1 = new PdfPCell(new Phrase(item.Nombre));
                    cel1.HorizontalAlignment = Element.ALIGN_LEFT;
                    cel1.FixedHeight = 20;
                    table1.AddCell(cel1);

                    cel1 = new PdfPCell(new Phrase(item.Cantidad.ToString()));
                    cel1.HorizontalAlignment = Element.ALIGN_CENTER;
                    cel1.FixedHeight = 20;
                    table1.AddCell(cel1);

                    cel1 = new PdfPCell(new Phrase("₡" + item.Precio.ToString("#,###,###.00")));
                    cel1.HorizontalAlignment = Element.ALIGN_LEFT;
                    cel1.FixedHeight = 20;
                    table1.AddCell(cel1);

                    cel1 = new PdfPCell(new Phrase("₡" + (item.Precio * item.Cantidad).ToString("#,###,###.00")));
                    cel1.HorizontalAlignment = Element.ALIGN_LEFT;
                    cel1.FixedHeight = 20;
                    table1.AddCell(cel1);

                    x++;
                }

                table1.WidthPercentage = 100;
                width = new float[] { 100f, 400f, 100f, 115, 125 };
                table1.SetWidths(width);
                table1.SpacingBefore = 20;
                doc.Add(table1);

                //TOTAL
                table1 = new PdfPTable(2);
                cel1 = new PdfPCell(new Phrase("SubTotal Gravado: ", f_12_bold));
                cel1.BackgroundColor = BaseColor.LIGHT_GRAY;
                cel2 = new PdfPCell(new Phrase("¢" + Calcula_SubTotal_Gravado().ToString("#,###,###.00"), f_12_normal));

                cel7 = new PdfPCell(new Phrase("Descuento Gravado: ", f_12_bold));
                cel7.BackgroundColor = BaseColor.LIGHT_GRAY;
                cel8 = new PdfPCell(new Phrase("¢0.00", f_12_normal));

                cel3 = new PdfPCell(new Phrase("Impuestos: ", f_12_bold));
                cel3.BackgroundColor = BaseColor.LIGHT_GRAY;
                cel4 = new PdfPCell(new Phrase("¢" + Calcula_IVA().ToString("#,###,###.00"), f_12_normal));

                PdfPCell cel9 = new PdfPCell(new Phrase("Total: ", f_12_bold));
                cel9.BackgroundColor = BaseColor.LIGHT_GRAY;
                PdfPCell cel10 = new PdfPCell(new Phrase( "¢" + CalculaMonto_Total_SinEnvio().ToString("#,###,###.00"), f_12_normal));

                PdfPCell cel11 = new PdfPCell(new Phrase("Otros: ", f_12_bold));
                cel11.BackgroundColor = BaseColor.LIGHT_GRAY;
                PdfPCell cel12 = new PdfPCell(new Phrase("¢" + Calcula_Envio().ToString("#,###,###.00"), f_12_normal));

                PdfPCell cel5 = new PdfPCell(new Phrase("Total a Pagar Colones: ", f_12_bold));
                cel5.BackgroundColor = BaseColor.LIGHT_GRAY;
                PdfPCell cel6 = new PdfPCell(new Phrase("¢" + CalculaMonto_Total().ToString("#,###,###.00"), f_12_normal_ColorRed));

                PdfPCell cel13 = new PdfPCell(new Phrase("Total a Pagar Dolares: ", f_12_bold));
                cel13.BackgroundColor = BaseColor.LIGHT_GRAY;
                PdfPCell cel14 = new PdfPCell(new Phrase( CalculaMonto_Total_Dolares().ToString("#,###,###.00"), f_12_normal_ColorRed));

                table1.WidthPercentage = 100;
                width = new float[] { 165, 50 };

                cel1.HorizontalAlignment = Element.ALIGN_RIGHT;
                cel1.FixedHeight = 20;
                cel3.HorizontalAlignment = Element.ALIGN_RIGHT;
                cel3.FixedHeight = 20;
                cel5.HorizontalAlignment = Element.ALIGN_RIGHT;
                cel5.FixedHeight = 20;
                cel7.HorizontalAlignment = Element.ALIGN_RIGHT;
                cel7.FixedHeight = 20;
                cel9.HorizontalAlignment = Element.ALIGN_RIGHT;
                cel9.FixedHeight = 20;
                cel11.HorizontalAlignment = Element.ALIGN_RIGHT;
                cel11.FixedHeight = 20;
                cel13.HorizontalAlignment = Element.ALIGN_RIGHT;
                cel13.FixedHeight = 20;

                cel2.HorizontalAlignment = Element.ALIGN_LEFT;
                cel4.HorizontalAlignment = Element.ALIGN_LEFT;
                cel6.HorizontalAlignment = Element.ALIGN_LEFT;
                cel8.HorizontalAlignment = Element.ALIGN_LEFT;
                cel10.HorizontalAlignment = Element.ALIGN_LEFT;
                cel12.HorizontalAlignment = Element.ALIGN_LEFT;
                cel6.HorizontalAlignment = Element.ALIGN_LEFT;
                cel14.HorizontalAlignment = Element.ALIGN_LEFT;

                table1.SetWidths(width);
                table1.AddCell(cel1);
                table1.AddCell(cel2);

                table1.AddCell(cel7);
                table1.AddCell(cel8);
                table1.AddCell(cel3);
                table1.AddCell(cel4);
                table1.AddCell(cel9);
                table1.AddCell(cel10);
                table1.AddCell(cel11);
                table1.AddCell(cel12);
                table1.AddCell(cel5);
                table1.AddCell(cel6);
                table1.AddCell(cel13);
                table1.AddCell(cel14);

                table1.SpacingAfter = 10;
                doc.Add(table1);
                #endregion



                string xmlGenerado = ObtenerXML();
                string xmlCifrado = Utilitarios.ComputeSha256Hash(xmlGenerado);
                parrafo = new iTextSharp.text.Paragraph(new Phrase("Codigo de XML enviado cifrado:\n " + xmlCifrado + " \n", f_12_normal));
                parrafo.Add(new Phrase("\nAutorizada mediante resolución Nº DGT - R - 48 - 2016 del 7 de octubre de 2016\n", f_12_normal));
                parrafo.Alignment = Element.ALIGN_JUSTIFIED;
                doc.Add(parrafo);

                parrafo = new iTextSharp.text.Paragraph(new Phrase(this.ObtenerXML(), f_12_normal));
                doc.NewPage();
                doc.Add(parrafo);

                doc.Close();//CERRAMOS EL DOCUMENTO
            }
        }

        /// <summary>
        /// Metodo que agrega una imagen/slogan al PDF creado
        /// </summary>
        /// <returns>void</returns>
        private void AgregaImagenPDF(Document objPdfDocument, string strFileImage)
        {
            iTextSharp.text.Image objImagePdf;
            //    Crea la imagen
            objImagePdf = iTextSharp.text.Image.GetInstance(strFileImage);
            // Cambia el tamaño de la imagen
            objImagePdf.ScaleToFit(64, 64);
            // Se indica que la imagen debe almacenarse como fondo
            objImagePdf.Alignment = iTextSharp.text.Image.ALIGN_RIGHT;
            // Coloca la imagen en una posición absoluta
            objImagePdf.SetAbsolutePosition(500, 700);
            objPdfDocument.Add(objImagePdf);
        }

        /// <summary>
        /// Metodo que setea la cultura de la clase
        /// </summary>
        /// <returns>void</returns>
        public void SetCulture()
        {
            // Colocar Cultura Estandar para Costa Rica
            CultureInfo Micultura = new CultureInfo("es-CR", false);
            Micultura.NumberFormat.CurrencySymbol = "¢";
            Micultura.NumberFormat.CurrencyDecimalDigits = 2;
            Micultura.NumberFormat.CurrencyDecimalSeparator = ".";
            Micultura.NumberFormat.CurrencyGroupSeparator = ",";
            int[] grupo = new int[] { 3, 3, 3 };
            Micultura.NumberFormat.CurrencyGroupSizes = grupo;
            Micultura.NumberFormat.NumberDecimalDigits = 2;
            Micultura.NumberFormat.NumberGroupSeparator = ",";
            Micultura.NumberFormat.NumberDecimalSeparator = ".";
            Micultura.NumberFormat.NumberGroupSizes = grupo;
            Thread.CurrentThread.CurrentCulture = Micultura;
        }


        #endregion



    }
}
