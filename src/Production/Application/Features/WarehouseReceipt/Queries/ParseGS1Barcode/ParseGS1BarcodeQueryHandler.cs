using Application.Features.WarehouseReceipt.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.WarehouseReceipt.Queries.ParseGS1Barcode
{
    public class ParseGS1BarcodeQueryHandler : IRequestHandler<ParseGS1BarcodeQuery, GS1BarcodeContentDTO>
    {
        public Task<GS1BarcodeContentDTO> Handle(ParseGS1BarcodeQuery request, CancellationToken cancellationToken)
        {
            string gs1_text = request.GS1Barcode;

            var appIdentifiers = new ApplicationIdentifier[] {
                new() { AI = "02", AILength = 2, DataMinLength = 14 , DataMaxLength = 14},
                new() { AI = "15", AILength = 2, DataMinLength = 6 , DataMaxLength = 6},
                new() { AI = "10", AILength = 2, DataMinLength = 1 , DataMaxLength = 20},
                new() { AI = "37", AILength = 2, DataMinLength = 1 , DataMaxLength = 8},
                new() { AI = "90", AILength = 2, DataMinLength = 1 , DataMaxLength = 30}
            };

            var result = new Dictionary<string, string>();

            var currentAi = "";

            while (gs1_text.Length != 0)
            {
                var ai = gs1_text[..2];

                var aiObj = appIdentifiers.FirstOrDefault(x => x.AI == ai);

                if (aiObj != null)
                {
                    if (aiObj.DataLengthIsConst)
                    {
                        var data = gs1_text[aiObj.AILength..(aiObj.AILength + aiObj.DataMaxLength)];

                        result.Add(key: ai, value: data);

                        gs1_text = gs1_text[(aiObj.AILength + aiObj.DataMaxLength)..];
                    }
                    else
                    {
                        var spaceIndex = gs1_text.IndexOf(' ');

                        var data = spaceIndex > -1 ? gs1_text[aiObj.AILength..spaceIndex] : gs1_text[aiObj.AILength..gs1_text.Length];

                        result.Add(key: ai, value: data);

                        gs1_text = spaceIndex == -1 ? "" : gs1_text[(spaceIndex + 1)..];
                    }
                }
                else
                {
                    break;
                }
            }

            return Task.FromResult(new GS1BarcodeContentDTO()
            {
                ContentGTIN = result["02"],
                BestBefore = result["15"],
                LotNumber = result["10"],
                InternalContent = result["90"],
                Quantity = Convert.ToInt32(result["37"])
            });
        }

        class ApplicationIdentifier
        {
            public string? AI { get; set; }

            public bool DataLengthIsConst => DataMinLength == DataMaxLength;

            public int AILength { get; set; }

            public int DataMinLength { get; set; }

            public int DataMaxLength { get; set; }
        }
    }
}