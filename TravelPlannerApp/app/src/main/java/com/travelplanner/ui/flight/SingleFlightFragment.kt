package com.travelplanner.ui.flight

import android.annotation.SuppressLint
import android.content.Intent
import android.os.Bundle
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.Button
import android.widget.TextView
import androidx.fragment.app.Fragment
import com.google.android.material.card.MaterialCardView
import com.travelplanner.R
import com.travelplanner.models.Flight
import com.travelplanner.ui.flight.search.SearchFlightActivity
import com.travelplanner.ui.flight.search.SearchFlightFragment
import com.travelplanner.ui.flight.search.SearchFlightFragment.Companion.EXTRA_FLIGHT_DESTINATION
import io.reactivex.subjects.BehaviorSubject
import java.time.format.DateTimeFormatter

class SingleFlightFragment : Fragment() {
    private var flight: BehaviorSubject<Flight> = BehaviorSubject.create()
    private var flightDestination: BehaviorSubject<String> = BehaviorSubject.create()

    @SuppressLint("CheckResult")
    override fun onCreateView(inflater: LayoutInflater, container: ViewGroup?, savedInstanceState: Bundle?): View? {
        val v = inflater.inflate(R.layout.fragment_single_flight, container, false)
        var travelId = activity?.intent?.getStringExtra(SearchFlightFragment.EXTRA_TRAVEL_ID)
        val noFlightCard = v.findViewById<MaterialCardView>(R.id.no_flight_card)
        val flightCard = v.findViewById<MaterialCardView>(R.id.flight_card )
        val formatter = DateTimeFormatter.ofPattern("EEE, d MMM yyyy HH:mm")
        val destination = v.findViewById<TextView>(R.id.flight_destination)
        val flightNumber = v.findViewById<TextView>(R.id.flight_number)
        val airlineId = v.findViewById<TextView>(R.id.airline_id)
        val departureTime = v.findViewById<TextView>(R.id.departure_flight_time)
        val terminalName = v.findViewById<TextView>(R.id.terminal_name)
        val arrivalTime = v.findViewById<TextView>(R.id.arrival_flight_time)
        val searchFlightButton = v.findViewById<Button>(R.id.add_new_flight_button)
        searchFlightButton.setOnClickListener {
            val intent = Intent(activity, SearchFlightActivity::class.java)
            intent.putExtra(SearchFlightFragment.EXTRA_FLIGHT_DESTINATION, flightDestination.value)
            intent.putExtra(SearchFlightFragment.EXTRA_TRAVEL_ID, travelId)
            activity?.startActivity(intent)
        }
        noFlightCard.visibility = View.VISIBLE
        flightCard.visibility = View.GONE
        flight.subscribe{
            if(it == null) {
                noFlightCard.visibility = View.VISIBLE
                flightCard.visibility = View.GONE
            } else {
                noFlightCard.visibility = View.GONE
                flightCard.visibility = View.VISIBLE
                destination.text = it.departure.airportCode
                flightNumber.text = it.flightNumber
                airlineId.text = it.airlineId
                departureTime.text = it.departure.scheduledTimeLocal.format(formatter)
                terminalName.text = it.departure.terminalName
                arrivalTime.text = it.arrival.scheduledTimeLocal.format(formatter)
            }
        }
        return v
    }

    companion object{
        val EXTRA_TRAVEL_ID = "travel_id"
    }

    fun setFlight(fl: Flight, dest: String){
        flight.onNext(fl)
        flightDestination.onNext(dest)
    }
}