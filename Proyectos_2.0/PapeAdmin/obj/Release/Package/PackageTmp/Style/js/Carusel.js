//function guardar() {
//    var tit1 = document.getElementById("tit1").value;
//    var tit2 = document.getElementById("tit2").value;
//    var img = document.getElementById("image").files.length;
//    if (tit1 == "" && tit2 == "" && img == 0) {
//        swal("Oops  ㋡ ", "Necesitas agregar una imagen", "info")
//    }
//    else {
//        if (tit1 == "" && tit2 == "" && img != 0) {
//            swal("Oops  ㋡ ", "Solo se guarda imagen", "info")
//        }
//        else {
//            if (tit1.length != 0 && tit2.length == 0 && img != 0) {
//                swal("Oops  ㋡ ", "Se guarda tit1 e imagen", "info")
//            }
//            else {
//                if (tit1 == "" && tit2 != "" && img != 0) {
//                    swal("Oops  ㋡ ", "Se guarda tit2 e imagen", "info")
//                }
//                else {
//                    if (tit1 != "" && tit2 != "" && img == 0) {
//                        swal("Oops  ㋡ ", "No se pueden guadar solo titulos", "info")
//                    }
//                    else {
//                        swal("Listo", "guardar los tres", "success")
//                        document.getElementById("tit1").value = "";
//                        document.getElementById("tit2").value = "";
//                    }
//                }
//            }

//        }

//    }

//};