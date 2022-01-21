using MessagingToolkit.QRCode.Codec;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

namespace AsansorTakip.Deneme
{
    public static class QrCodeGenerator
    {
        public static Bitmap GenerateQrCode(string metin)
        {
            QRCodeEncoder qr = new QRCodeEncoder();
            var resim = qr.Encode(metin);
            return resim;
        }
    }
}