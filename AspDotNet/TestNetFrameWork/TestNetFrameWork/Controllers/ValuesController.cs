using MPKICrypto;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;

namespace TestNetFrameWork.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values


        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }

        public string Get()
        {
            try
            {
                var inputPdf = "C:\\Users\\lenht\\WorkSpace\\QLVB\\qlvbDnn\\Uploads\\KySo\\060624014407Nhật ký xử lý.signed.pdf";
                var exist = File.Exists(inputPdf);

                MPKICrypto.PdfVerifier verifier = new MPKICrypto.PdfVerifier(inputPdf);
                List<PDFSignatureInfo> lst = verifier.Verify().OrderByDescending(x => x.SigningTime).ToList();
                if (lst.Any())
                {
                    int STT = 0;
                    foreach (PDFSignatureInfo info in lst)
                    {
                        MPKICrypto.CertInfo cert = new MPKICrypto.CertInfo(info.SignerCert);
                        
                    }
                   
                }
                return string.Empty;
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }
    }
}
