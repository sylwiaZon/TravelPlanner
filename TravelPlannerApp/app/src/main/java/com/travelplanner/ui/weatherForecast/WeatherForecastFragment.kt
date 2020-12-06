package com.travelplanner.ui.weatherForecast

import android.os.Bundle
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import androidx.fragment.app.Fragment
import androidx.lifecycle.Observer
import androidx.lifecycle.ViewModelProvider
import androidx.recyclerview.widget.LinearLayoutManager
import androidx.recyclerview.widget.RecyclerView
import com.travelplanner.R
import com.travelplanner.ui.tour.TourAdapter
import com.travelplanner.ui.tour.TourViewModel

class WeatherForecastFragment : Fragment() {

    lateinit var viewModel: WeatherForecastViewModel

    override fun onCreateView(inflater: LayoutInflater, container: ViewGroup?, savedInstanceState: Bundle?): View? {
        val v = inflater.inflate(R.layout.fragment_weather_forecast, container, false)
        viewModel =
                ViewModelProvider(this).get(WeatherForecastViewModel::class.java)
        activity?.intent?.getStringExtra(EXTRA_TRAVEL_DESTINATION)?.let {
            viewModel.setCityName(it)
        }
        val recycler = v.findViewById<RecyclerView>(R.id.daily_weather_forecast_recycler)
        val adapter = WeatherForecastAdapter()
        recycler.adapter = adapter
        recycler.layoutManager = LinearLayoutManager(context)
        viewModel.weatherForecast.observe(viewLifecycleOwner, Observer {
            adapter.setData(it)
        })
        return v
    }

    companion object {
        val EXTRA_TRAVEL_DESTINATION = "travel_destination"
    }
}