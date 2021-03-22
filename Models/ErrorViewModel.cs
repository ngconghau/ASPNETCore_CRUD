using System;

namespace CRUD_APSNET.Models
{
    public class ErrorViewModel
    {
        public string RequestId
        {
            get; set;
        }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
