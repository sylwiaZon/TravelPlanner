using DomainTour = TravelPlanner.Core.DomainModels.Tour;
using DbTour = TravelPlanner.Core.DataBaseModels.Tour;
using TriposoTour = TravelPlanner.Core.Triposo.Tour;

namespace TravelPlanner.Services.Converters
{
    public class TourConverter
    {
        public static DomainTour ToDomainTour(TriposoTour tour)
        {
            return new DomainTour
            {
                Price = tour.Price?.Amount,
                PriceCurrency = tour.Price?.Currency,
                Vendor = tour.Vendor,
                VendorTourUrl = tour.VendorTourUrl,
                Duartion = tour.Duartion,
                DurationUnit = tour.DurationUnit,
                Id = tour.Id,
                Intro = tour.Intro,
                Name = tour.Name
            };
        }

        public static DomainTour ToDomainTour(DbTour tour)
        {
            return new DomainTour
            {
                Price = tour.Price,
                PriceCurrency = tour.PriceCurrency,
                Vendor = tour.Vendor,
                VendorTourUrl = tour.VendorTourUrl,
                Duartion = tour.Duartion,
                DurationUnit = tour.DurationUnit,
                Id = tour.Id,
                Intro = tour.Intro,
                Name = tour.Name
            };
        }

        public static DbTour ToDbTour(DomainTour tour)
        {
            return new DbTour
            {
                Price = tour.Price,
                PriceCurrency = tour.PriceCurrency,
                Vendor = tour.Vendor,
                VendorTourUrl = tour.VendorTourUrl,
                Duartion = tour.Duartion,
                DurationUnit = tour.DurationUnit,
                Id = tour.Id,
                Intro = tour.Intro,
                Name = tour.Name
            };
        }

        public static DbTour ToDbTour(TriposoTour tour)
        {
            return new DbTour
            {
                Price = tour.Price?.Amount,
                PriceCurrency = tour.Price?.Currency,
                Vendor = tour.Vendor,
                VendorTourUrl = tour.VendorTourUrl,
                Duartion = tour.Duartion,
                DurationUnit = tour.DurationUnit,
                Id = tour.Id,
                Intro = tour.Intro,
                Name = tour.Name
            };
        }

    }
}
