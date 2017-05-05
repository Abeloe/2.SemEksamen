using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eksamen2Semester.Model;

namespace Eksamen2Semester.Singletonz
{
     class LokationKatalogSingleton
    {
            private static LokationKatalogSingleton LokationKatalogSingleton1;

            public static LokationKatalogSingleton LokationKatalogSingletons
            {

                get
                {
                    return LokationKatalogSingleton1 ?? (LokationKatalogSingleton1 = new LokationKatalogSingleton());
                }
            }

            public ObservableCollection<Lokation> Lokations { get; set; }

            public LokationKatalogSingleton()
            {
                Lokations = new ObservableCollection<Lokation>();
            }
        }
    }
