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

class SingleFlightFragment : Fragment() {
    private var flight: BehaviorSubject<Flight> = BehaviorSubject.create()

    override fun onCreateView(inflater: LayoutInflater, container: ViewGroup?, savedInstanceState: Bundle?): View? {
        val v = inflater.inflate(R.layout.fragment_single_flight, container, false)
        val destination = v.findViewById<TextView>(R.id.flight_destination)
        flight.subscribe{
            destination.text = it.departure.airportCode
        }
        return v
    }

    fun setFlight(fl: Flight){
        flight.onNext(fl)
    }
}