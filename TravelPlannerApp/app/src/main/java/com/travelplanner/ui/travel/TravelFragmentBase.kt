package com.travelplanner.ui.travel

import android.content.Intent
import android.os.Bundle
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.ImageView
import android.widget.TextView
import androidx.constraintlayout.widget.ConstraintLayout
import androidx.fragment.app.Fragment
import androidx.lifecycle.Observer
import androidx.lifecycle.ViewModelProvider
import com.bumptech.glide.Glide
import com.google.android.material.chip.Chip
import com.travelplanner.R
import com.travelplanner.models.WeatherForecast
import com.travelplanner.ui.cityWalk.CityWalkActivity
import com.travelplanner.ui.cityWalk.CityWalkAdapter
import com.travelplanner.ui.cityWalk.CityWalkFragment
import com.travelplanner.ui.dayPlan.DayPlanActivity
import com.travelplanner.ui.dayPlan.DayPlanFragment
import com.travelplanner.ui.flight.FlightActivity
import com.travelplanner.ui.flight.FlightFragment
import com.travelplanner.ui.hotel.HotelActivity
import com.travelplanner.ui.hotel.HotelFragment
import com.travelplanner.ui.localHighlights.LocalHighlightsActivity
import com.travelplanner.ui.localHighlights.LocalHighlightsAdapter
import com.travelplanner.ui.localHighlights.LocalHighlightsFragment
import com.travelplanner.ui.tour.TourActivity
import com.travelplanner.ui.tour.TourFragment
import com.travelplanner.ui.weatherForecast.WeatherForecastActivity
import com.travelplanner.ui.weatherForecast.WeatherForecastFragment

abstract class TravelFragmentBase : Fragment() {

    protected lateinit var travelViewModel: TravelViewModelBase

    abstract fun getViewModel(): TravelViewModelBase

    override fun onCreateView(
            inflater: LayoutInflater,
            container: ViewGroup?,
            savedInstanceState: Bundle?
    ): View? {
        travelViewModel = getViewModel()
        travelViewModel.initTravel()
        val root = inflater.inflate(R.layout.fragment_travel, container, false)
        val noIncTravel = root?.findViewById<ConstraintLayout>(R.id.no_incoming_travel)
        noIncTravel?.visibility = View.GONE
        val textView: TextView = root.findViewById(R.id.travel_date)
        travelViewModel.date.observe(viewLifecycleOwner, Observer {
            textView.text = it
        })
        val image = root?.findViewById<ImageView>(R.id.travel_image)
        val destinationCity = root?.findViewById<TextView>(R.id.travel_destination_city)
        val destinationCountry = root?.findViewById<TextView>(R.id.travel_destination_country)
        val dayPlanButton = root.findViewById<Chip>(R.id.day_plans_chip)
        val cityWalkButton = root.findViewById<Chip>(R.id.city_walk_chip)
        val hotelButton = root.findViewById<Chip>(R.id.hotel_chip)
        val flightsButton = root.findViewById<Chip>(R.id.flights_chip)
        val localHighlightsButton = root.findViewById<Chip>(R.id.local_highlights_chip)
        val toursButton = root.findViewById<Chip>(R.id.tours_chip)
        val weatherButton = root.findViewById<Chip>(R.id.weather_forecast_chip)
        travelViewModel.travel.observe(viewLifecycleOwner, Observer{t ->
            destinationCity?.text = t?.travelDestination?.city
            destinationCountry?.text = t?.travelDestination?.country
            if(t?.photoUrl == null || t?.photoUrl == "")
                image?.visibility = View.GONE
            else
                image?.let {
                    Glide
                            .with(root.context)
                            .load(t?.photoUrl)
                            .into(it)
                }
            dayPlanButton.setOnClickListener{
                val intent = Intent(activity, DayPlanActivity::class.java)
                intent.putExtra(DayPlanFragment.EXTRA_TRAVEL_ID, t?.travelId)
                activity?.startActivity(intent)
            }
            cityWalkButton.setOnClickListener{
                val intent = Intent(activity, CityWalkActivity::class.java)
                intent.putExtra(CityWalkFragment.EXTRA_TRAVEL_ID, t?.travelId)
                activity?.startActivity(intent)
            }
            hotelButton.setOnClickListener{
                val intent = Intent(activity, HotelActivity::class.java)
                intent.putExtra(HotelFragment.EXTRA_TRAVEL_ID, t?.travelId)
                activity?.startActivity(intent)
            }
            flightsButton.setOnClickListener{
                val intent = Intent(activity, FlightActivity::class.java)
                intent.putExtra(FlightFragment.EXTRA_TRAVEL_ID, t?.travelId)
                activity?.startActivity(intent)
            }
            localHighlightsButton.setOnClickListener{
                val intent = Intent(activity, LocalHighlightsActivity::class.java)
                intent.putExtra(LocalHighlightsFragment.EXTRA_TRAVEL_ID, t?.travelId)
                activity?.startActivity(intent)
            }
            toursButton.setOnClickListener{
                val intent = Intent(activity, TourActivity::class.java)
                intent.putExtra(TourFragment.EXTRA_TRAVEL_ID, t?.travelId)
                activity?.startActivity(intent)
            }
            weatherButton.setOnClickListener{
                val intent = Intent(activity, WeatherForecastActivity::class.java)
                intent.putExtra(WeatherForecastFragment.EXTRA_TRAVEL_DESTINATION, t?.travelDestination?.city)
                activity?.startActivity(intent)
            }
        })
        return root
    }


}