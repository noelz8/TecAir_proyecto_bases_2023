using System;
using System.Collections.Generic;

namespace webApi.Models;

public partial class Origen
{
    public string Codigoaeropuertoorigen { get; set; }

    public string Ciudad { get; set; }

    public string Pais { get; set; }

    public string Puertaingreso { get; set; }

    public DateTime? Horasalida { get; set; }

}
