using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de FacturaCompra
/// </summary>
public class FacturaCompra
{
    private String _numeroFactura;

    public String NumeroFactura
    {
        get { return _numeroFactura; }
        set { _numeroFactura = value; }
    }
    private String _cedulaContribuyente;

    public String CedulaContribuyente
    {
        get { return _cedulaContribuyente; }
        set { _cedulaContribuyente = value; }
    }
    private String _cedulaProveedor;

    public String CedulaProveedor
    {
        get { return _cedulaProveedor; }
        set { _cedulaProveedor = value; }
    }
    private DateTime _fecha;

    public DateTime Fecha
    {
        get { return _fecha; }
        set { _fecha = value; }
    }
    private int _tipoFactura;

    public int TipoFactura
    {
        get { return _tipoFactura; }
        set { _tipoFactura = value; }
    }
    private int _plazo;

    public int Plazo
    {
        get { return _plazo; }
        set { _plazo = value; }
    }
    private DateTime _vencimiento;

    public DateTime Vencimiento
    {
        get { return _vencimiento; }
        set { _vencimiento = value; }
    }
    private Double _montoExento;

    public Double MontoExento
    {
        get { return _montoExento; }
        set { _montoExento = value; }
    }
    private Double _porcentajeDescuentoExento;

    public Double PorcentajeDescuentoExento
    {
        get { return _porcentajeDescuentoExento; }
        set { _porcentajeDescuentoExento = value; }
    }
    private Double _descuentoExento;

    public Double DescuentoExento
    {
        get { return _descuentoExento; }
        set { _descuentoExento = value; }
    }
    private Double _subtotalExento;

    public Double SubtotalExento
    {
        get { return _subtotalExento; }
        set { _subtotalExento = value; }
    }
    private Double _montoGravado;

    public Double MontoGravado
    {
        get { return _montoGravado; }
        set { _montoGravado = value; }
    }
    private Double _porcentajeDescuentoGravado;

    public Double PorcentajeDescuentoGravado
    {
        get { return _porcentajeDescuentoGravado; }
        set { _porcentajeDescuentoGravado = value; }
    }
    private Double _descuentoGravado;

    public Double DescuentoGravado
    {
        get { return _descuentoGravado; }
        set { _descuentoGravado = value; }
    }
    private Double _subtotalGravado;

    public Double SubtotalGravado
    {
        get { return _subtotalGravado; }
        set { _subtotalGravado = value; }
    }

    private Double _impuestoVenta;

    public Double ImpuestoVenta
    {
        get { return _impuestoVenta; }
        set { _impuestoVenta = value; }
    }

    private Double _flete;

    public Double Flete
    {
        get { return _flete; }
        set { _flete = value; }
    }
    private Double _totalFactura;

    public Double TotalFactura
    {
        get { return _totalFactura; }
        set { _totalFactura = value; }
    }

	public FacturaCompra()
	{
		//
		// TODO: Agregar aquí la lógica del constructor
		//
	}

    public FacturaCompra(Object[] datos) {
        string[] formatsDate = { "dd/MM/yyyy hh:mm:ss tt", "dd/MM/yyyy" };
        this._numeroFactura = datos[0].ToString();
        this._cedulaContribuyente = datos[1].ToString();
        this._cedulaProveedor = datos[2].ToString();
        this._fecha = DateTime.ParseExact(replaceDate(datos[3].ToString()), formatsDate, CultureInfo.InvariantCulture, DateTimeStyles.None);
        this._tipoFactura = Convert.ToInt32(datos[4].ToString());
        this._plazo = Convert.ToInt32(datos[5].ToString());
        this._vencimiento = DateTime.ParseExact(replaceDate(datos[6].ToString()), formatsDate, CultureInfo.InvariantCulture, DateTimeStyles.None);
        this._montoExento = Convert.ToDouble(replaceDotComa(datos[7].ToString()), CultureInfo.InvariantCulture);
        this._porcentajeDescuentoExento = Convert.ToDouble(replaceDotComa(datos[8].ToString()), CultureInfo.InvariantCulture);
        this._descuentoExento = Convert.ToDouble(replaceDotComa(datos[9].ToString()), CultureInfo.InvariantCulture);
        this._subtotalExento = Convert.ToDouble(replaceDotComa(datos[10].ToString()), CultureInfo.InvariantCulture);
        this._montoGravado = Convert.ToDouble(replaceDotComa(datos[11].ToString()), CultureInfo.InvariantCulture);
        this._porcentajeDescuentoGravado = Convert.ToDouble(replaceDotComa(datos[12].ToString()), CultureInfo.InvariantCulture);
        this._descuentoGravado = Convert.ToDouble(replaceDotComa(datos[13].ToString()), CultureInfo.InvariantCulture);
        this._subtotalGravado = Convert.ToDouble(replaceDotComa(datos[14].ToString()), CultureInfo.InvariantCulture);
        this._impuestoVenta = Convert.ToDouble(replaceDotComa(datos[15].ToString()), CultureInfo.InvariantCulture);
        this._flete = Convert.ToDouble(replaceDotComa(datos[16].ToString()), CultureInfo.InvariantCulture);
        this._totalFactura = Convert.ToDouble(replaceDotComa(datos[17].ToString()), CultureInfo.InvariantCulture);
    }

    public String replaceDotComa(String monto)
    {
        String resultado = "";
        resultado = monto.Replace(",", ".");
        return resultado;
    }

    public String replaceDate(String fecha)
    {
        String resultado = "";
        if (fecha.Contains("a.m."))
        {
            resultado = fecha.Replace("a.m.", "AM");
        }
        else if (fecha.Contains("p.m."))
        {
            resultado = fecha.Replace("p.m.", "PM");
        }
        else
        {
            resultado = fecha;
        }
        return resultado;
    }

}