using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    public class MensajePredeterminado
    {
        #region Operaciones
        public const string GuardadoConExito = "Registro guardado con éxito.";
        public const string AnuladoConExito = "Registro anulado con éxito.";
        public const string EliminadoConExito = "Registro eliminado con éxito.";
        public const string ActualizadoConExito = "Registro actualizado con éxito.";
        public const string ComandoEjecutadoConExito = "Comando ejecutado con éxito.";
        #endregion

        #region Busqueda
        public const string BusquedaExitosa = "Consulta procesada con éxito.";
        #endregion

        #region Errores de Operaciones
        public const string ErrorEjecucionComando = "Error al procesar el comando. Intente nuevamente.";
        public const string BusquedaSinRegistros = "No se encontró registros.";
        public const string ErrorInterno = "Error interno de servidor.";
        #endregion

        #region Usuario
        public const string ContrasenhaErronea = "La contraseña ingresada es incorrecta.";
        public const string ContrasenhaCambiada = "La contraseña cambiada con éxito.";
        public const string UsuarioNoHabilitado = "El usuario no está habilitado.";
        public const string UsuarioSinCredenciales = "Usted no tiene permisos para realizar esta acción.";
        public const string UsuarioAdministradorProtegido = "Usuario administrador protegido.";
        #endregion

     
        #region Script
        public const string ScriptEjecutadoConExito = "Script ejecutado con éxito.";
        public const string ErrorAlEjecutarScript = "Error al ejecutar el script.";
        public const string BaseDeDatosActualizada= "La base de datos se encuentra actualizada.";
        #endregion


    }
}
