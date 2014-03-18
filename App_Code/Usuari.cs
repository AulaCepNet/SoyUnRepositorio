using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de Usuari
/// </summary>
public class Usuari
{
    private String _NomUsuari;

    public String NomUsuari
    {
        get { return _NomUsuari; }
        set { _NomUsuari = value; }
    }

    private String _Email;

    public String Email
    {
        get { return _Email; }
        set { _Email = value; }
    }

    private String _Cognoms;

    public String Cognoms
    {
        get { return _Cognoms; }
        set { _Cognoms = value; }
    }

    private String _Nom;

    public String Nom
    {
        get { return _Nom; }
        set { _Nom = value; }
    }

	public Usuari()
	{
       
		//
		// TODO: Agregar aquí la lógica del constructor
		//
	}
}