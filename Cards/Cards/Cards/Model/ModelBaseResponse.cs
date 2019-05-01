using System;
using System.Collections.Generic;
using System.Text;

namespace Cards.Model
{
  public  class ModelBaseResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public string JsonResult { get; set; }

        public void SetDefaulSuccess()
        {
            Success = true;
            Message = "La operación se completo con éxito";
        }

        public void SetDefaulFailure()
        {
            Success = false;
            Message = "La operación no tuvo éxito";
        }

        public void SetDefaulError()
        {
            Success = false;
            Message = "Ocurrio un error durante la ejecución, consulte al administrador";
        }
    }
}
