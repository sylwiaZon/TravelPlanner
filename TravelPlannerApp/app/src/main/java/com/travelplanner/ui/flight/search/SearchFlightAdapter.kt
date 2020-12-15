package com.travelplanner.ui.flight.search

import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.TextView
import androidx.recyclerview.widget.RecyclerView
import com.google.android.material.card.MaterialCardView
import com.travelplanner.R
import com.travelplanner.models.Airport
import com.travelplanner.models.Flight
import java.time.format.DateTimeFormatter

class  SearchFlightAdapter(val onFlightChosen: (Flight) -> Unit): RecyclerView.Adapter<SearchFlightAdapter.ViewHolder>() {
    class ViewHolder(itemView: View) : RecyclerView.ViewHolder(itemView) {}

    private var flightsList: List<Flight> = emptyList()

    override fun onCreateViewHolder(parent: ViewGroup, viewType: Int): ViewHolder {
        val itemView: View = LayoutInflater.from(parent.context).inflate(R.layout.item_search_flight, parent, false)
        return ViewHolder(itemView)
    }

    override fun getItemCount(): Int {
        return flightsList.size
    }

    override fun onBindViewHolder(holder: ViewHolder, position: Int) {
        val v = holder.itemView
        val card = v.findViewById<MaterialCardView>(R.id.search_flight_card)
        val formatter = DateTimeFormatter.ofPattern("EEE, d MMM yyyy HH:mm")
        val destination = v.findViewById<TextView>(R.id.flight_destination)
        val flightNumber = v.findViewById<TextView>(R.id.flight_number)
        val airlineId = v.findViewById<TextView>(R.id.airline_id)
        val departureTime = v.findViewById<TextView>(R.id.departure_flight_time)
        val terminalName = v.findViewById<TextView>(R.id.terminal_name)
        val arrivalTime = v.findViewById<TextView>(R.id.arrival_flight_time)
        destination.text = flightsList[position].departure.airportCode
        flightNumber.text = flightsList[position].flightNumber
        airlineId.text = flightsList[position].airlineId
        departureTime.text = flightsList[position].departure.scheduledTimeLocal.format(formatter)
        terminalName.text = flightsList[position].departure.terminalName
        arrivalTime.text = flightsList[position].arrival.scheduledTimeLocal.format(formatter)
        card.setOnClickListener{
            onFlightChosen(flightsList[position])
        }
    }

    public fun setData(data: List<Flight>) {
        flightsList = data
        notifyDataSetChanged()
    }
}