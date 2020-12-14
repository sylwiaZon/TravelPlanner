package com.travelplanner.ui.flight.search

import android.annotation.SuppressLint
import android.os.Bundle
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.Button
import android.widget.EditText
import android.widget.TextView
import androidx.fragment.app.Fragment
import com.google.android.material.card.MaterialCardView
import com.travelplanner.R
import com.travelplanner.models.Flight
import com.travelplanner.models.Location
import com.travelplanner.ui.location.showLocationDialog
import io.reactivex.subjects.BehaviorSubject
import java.time.format.DateTimeFormatter


class SearchFlightFragment : Fragment() {

    override fun onCreateView(inflater: LayoutInflater, container: ViewGroup?, savedInstanceState: Bundle?): View? {
        val v = inflater.inflate(R.layout.fragment_search_flight, container, false)
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

        var fromLocation: Location? = null
        var toLocation: Location? = null
        fromFlightButton.setOnClickListener {
            context?.showLocationDialog(fromFlightInput.text.toString()){
                fromLocation = it
            }
        }

        toFlightButton.setOnClickListener {
            context?.showLocationDialog(toFlightInput.text.toString()){
                toLocation = it
            }
        }
        return v
    }
}