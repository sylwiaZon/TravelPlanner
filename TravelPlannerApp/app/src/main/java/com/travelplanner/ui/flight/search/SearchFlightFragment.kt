package com.travelplanner.ui.flight.search

import android.annotation.SuppressLint
import android.os.Bundle
import android.util.Log
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.Button
import android.widget.EditText
import android.widget.TextView
import androidx.fragment.app.Fragment
import com.google.android.material.card.MaterialCardView
import com.travelplanner.R
import com.travelplanner.api.applySchedulers
import com.travelplanner.di.DIContainer
import com.travelplanner.models.Airport
import com.travelplanner.models.Flight
import com.travelplanner.models.Location
import com.travelplanner.ui.dayPlan.DayPlanFragment
import com.travelplanner.ui.flight.search.airport.showAirportDialog
import com.travelplanner.ui.location.showLocationDialog
import io.reactivex.subjects.BehaviorSubject
import java.time.LocalDate
import java.time.format.DateTimeFormatter
import java.time.format.FormatStyle


class SearchFlightFragment : Fragment() {

    override fun onCreateView(inflater: LayoutInflater, container: ViewGroup?, savedInstanceState: Bundle?): View? {
        val v = inflater.inflate(R.layout.fragment_search_flight, container, false)
        val formatter = DateTimeFormatter.ofLocalizedDate(FormatStyle.LONG)
        var flightDestination = activity?.intent?.getStringExtra(EXTRA_FLIGHT_DESTINATION)
        var travelId = activity?.intent?.getStringExtra(EXTRA_TRAVEL_ID)

        val fromFlightInput = v.findViewById<EditText>(R.id.from_flight_location_input)
        val fromFlightButton = v.findViewById<Button>(R.id.from_flight_location_button)
        val fromFlightCard = v.findViewById<MaterialCardView>(R.id.from_flight_card)
        val fromFlightCity = v.findViewById<TextView>(R.id.from_flight_card_city)
        val fromFlightAirportCode = v.findViewById<TextView>(R.id.from_flight_card_airport_code)
        val fromFlightAirportDistance = v.findViewById<TextView>(R.id.from_flight_card_airport_distance)
        fromFlightCard.visibility = View.GONE

        val toFlightInput = v.findViewById<EditText>(R.id.to_flight_location_input)
        val toFlightButton = v.findViewById<Button>(R.id.to_flight_location_button)
        val toFlightCard = v.findViewById<MaterialCardView>(R.id.to_flight_card)
        val toFlightCity = v.findViewById<TextView>(R.id.to_flight_card_city)
        val toFlightAirportCode = v.findViewById<TextView>(R.id.to_flight_card_airport_code)
        val toFlightAirportDistance = v.findViewById<TextView>(R.id.to_flight_card_airport_distance)
        toFlightCard.visibility = View.GONE

        val setDate = v.findViewById<Button>(R.id.flights_date_button)
        val flightDate = v.findViewById<TextView>(R.id.flight_date)
        var selectedDate: LocalDate? = null
        var fromLocation: Location? = null
        var toLocation: Location? = null
        var fromAirport: Airport? = null
        var toAirport: Airport? = null
        setDate.setOnClickListener{
            context?.showFlightDatePickerDialog { localDate ->
                selectedDate = localDate
                flightDate.text = localDate.format(formatter)
            }
        }

        val searchFlightButton = v.findViewById<Button>(R.id.search_flights_button)
        searchFlightButton.visibility = View.GONE
        searchFlightButton.setOnClickListener{
            context?.showSearchFlightDialog(fromAirport?.airportCode!!, toAirport?.airportCode!!, selectedDate!!){
                addFlight(it, flightDestination!!, travelId!!)
            }
        }

        fromFlightButton.setOnClickListener {
            context?.showLocationDialog(fromFlightInput.text.toString()){
                fromLocation = it
                context?.showAirportDialog(fromLocation?.latitude!!, fromLocation?.longitude!!){
                    fromAirport = it
                    fromFlightCity.text = it.names[0]
                    fromFlightAirportCode.text = it.airportCode
                    fromFlightAirportDistance.text = it.distanceValue.toString() + " " + it.distanceUnit
                    fromFlightCard.visibility = View.VISIBLE
                    if(fromAirport != null && toAirport != null) searchFlightButton.visibility = View.VISIBLE
                }
            }
        }

        toFlightButton.setOnClickListener {
            context?.showLocationDialog(toFlightInput.text.toString()){
                toLocation = it
                context?.showAirportDialog(toLocation?.latitude!!, toLocation?.longitude!!){
                    toAirport = it
                    toFlightCity.text = it.names[0]
                    toFlightAirportCode.text = it.airportCode
                    toFlightAirportDistance.text = it.distanceValue.toString() + " " + it.distanceUnit
                    toFlightCard.visibility = View.VISIBLE
                    if(fromAirport != null && toAirport != null) searchFlightButton.visibility = View.VISIBLE
                }
            }
        }
        return v
    }

    companion object{
        val EXTRA_FLIGHT_DESTINATION = "flight_dest"
        val EXTRA_TRAVEL_ID = "travel_id"
    }

    private fun addFlight(flight: Flight, destination: String, travelId: String){
        val travelApiService = DIContainer.travelApiService
        travelApiService.postFlight(flight, destination, travelId)
    }
}

