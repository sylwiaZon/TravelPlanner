package com.travelplanner.ui.flight

import android.os.Bundle
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.TextView
import androidx.fragment.app.Fragment
import com.travelplanner.R
import com.travelplanner.models.Flight
import io.reactivex.subjects.BehaviorSubject
import java.time.format.DateTimeFormatter
import java.time.format.FormatStyle

class SingleFlightFragment : Fragment() {
    private var flight: BehaviorSubject<Flight> = BehaviorSubject.create()

    override fun onCreateView(inflater: LayoutInflater, container: ViewGroup?, savedInstanceState: Bundle?): View? {
        val v = inflater.inflate(R.layout.fragment_single_flight, container, false)
        val formatter = DateTimeFormatter.ofPattern("EEE, d MMM yyyy HH:mm")
        val destination = v.findViewById<TextView>(R.id.flight_destination)
        val flightNumber = v.findViewById<TextView>(R.id.flight_number)
        val airlineId = v.findViewById<TextView>(R.id.airline_id)
        val departureTime = v.findViewById<TextView>(R.id.departure_flight_time)
        val terminalName = v.findViewById<TextView>(R.id.terminal_name)
        val arrivalTime = v.findViewById<TextView>(R.id.arrival_flight_time)
        flight.subscribe{
            destination.text = it.departure.airportCode
            flightNumber.text = it.flightNumber
            airlineId.text = it.airlineId
            departureTime.text = it.departure.scheduledTimeLocal.format(formatter)
            terminalName.text = it.departure.terminalName
            arrivalTime.text = it.arrival.scheduledTimeLocal.format(formatter)
        }
        return v
    }

    fun setFlight(fl: Flight){
        flight.onNext(fl)
    }
}