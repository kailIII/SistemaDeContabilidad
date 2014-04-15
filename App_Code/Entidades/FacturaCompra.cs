﻿using System;
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
    private float _montoExento;

    public float MontoExento
    {
        get { return _montoExento; }
        set { _montoExento = value; }
    }
    private float _porcentajeDescuentoExento;

    public float PorcentajeDescuentoExento
    {
        get { return _porcentajeDescuentoExento; }
        set { _porcentajeDescuentoExento = value; }
    }
    private float _descuentoExento;

    public float DescuentoExento
    {
        get { return _descuentoExento; }
        set { _descuentoExento = value; }
    }
    private float _subtotalExento;

    public float SubtotalExento
    {
        get { return _subtotalExento; }
        set { _subtotalExento = value; }
    }
    private float _montoGravado;

    public float MontoGravado
    {
        get { return _montoGravado; }
        set { _montoGravado = value; }
    }
    private float _porcentajeDescuentoGravado;

    public float PorcentajeDescuentoGravado
    {
        get { return _porcentajeDescuentoGravado; }
        set { _porcentajeDescuentoGravado = value; }
    }
    private float _descuentoGravado;

    public float DescuentoGravado
    {
        get { return _descuentoGravado; }
        set { _descuentoGravado = value; }
    }
    private float _subtotalGravado;

    public float SubtotalGravado
    {
        get { return _subtotalGravado; }
        set { _subtotalGravado = value; }
    }

    private float _impuestoVenta;

    public float ImpuestoVenta
    {
        get { return _impuestoVenta; }
        set { _impuestoVenta = value; }
    }

    private float _flete;

    public float Flete
    {
        get { return _flete; }
        set { _flete = value; }
    }
    private float _totalFactura;

    public float TotalFactura
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
        CultureInfo culture = new CultureInfo("en-US");
        this._numeroFactura = datos[0].ToString();
        this._cedulaContribuyente = datos[1].ToString();
        this._cedulaProveedor = datos[2].ToString();
        this._fecha = Convert.ToDateTime(datos[3].ToString());
        this._tipoFactura = Convert.ToInt32(datos[4].ToString());
        this._plazo = Convert.ToInt32(datos[5].ToString());
        this._vencimiento = Convert.ToDateTime(datos[6].ToString());
        this._montoExento = float.Parse(replaceDotComa(datos[7].ToString()), culture.NumberFormat);
        this._porcentajeDescuentoExento = float.Parse(replaceDotComa(datos[8].ToString()), culture.NumberFormat);
        this._descuentoExento = float.Parse(replaceDotComa(datos[9].ToString()), culture.NumberFormat);
        this._subtotalExento = float.Parse(replaceDotComa(datos[10].ToString()), culture.NumberFormat);
        this._montoGravado = float.Parse(replaceDotComa(datos[11].ToString()), culture.NumberFormat);
        this._porcentajeDescuentoGravado = float.Parse(replaceDotComa(datos[12].ToString()), culture.NumberFormat);
        this._descuentoGravado = float.Parse(replaceDotComa(datos[13].ToString()), culture.NumberFormat);
        this._subtotalGravado = float.Parse(replaceDotComa(datos[14].ToString()), culture.NumberFormat);
        this._impuestoVenta = float.Parse(replaceDotComa(datos[15].ToString()), culture.NumberFormat);
        this._flete = float.Parse(replaceDotComa(datos[16].ToString()), culture.NumberFormat);
        this._totalFactura = float.Parse(replaceDotComa(datos[17].ToString()), culture.NumberFormat);
    }

    public String replaceDotComa(String monto)
    {
        String resultado = "";
        resultado = monto.Replace(",", ".");
        return resultado;
    }
}