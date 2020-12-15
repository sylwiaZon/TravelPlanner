package com.travelplanner.ui.flight.search.airport

import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.TextView
import androidx.recyclerview.widget.RecyclerView
import com.google.android.material.card.MaterialCardView
import com.travelplanner.R
import com.travelplanner.models.Airport
import com.travelplanner.models.Location

class SearchAirportAdapter(val onAirportChosen: (Airport) -> Unit): RecyclerView.Adapter<SearchAirportAdapter.ViewHolder>() {
    class ViewHolder(itemView: View) : RecyclerView.ViewHolder(itemView) {}

    private var airportsList: List<Airport> = emptyList()

    override fun onCreateViewHolder(parent: ViewGroup, viewType: Int): ViewHolder {
        val itemView: View = LayoutInflater.from(parent.context).inflate(R.layout.item_airport_search, parent, false)
        return ViewHolder(itemView)
    }

    override fun getItemCount(): Int {
        return airportsList.size
    }

    override fun onBindViewHolder(holder: ViewHolder, position: Int) {
        val holderView = holder.itemView
        val card = holderView.findViewById<MaterialCardView>(R.id.airport_card)
        val locationDestination = holderView.findViewById<TextView>(R.id.flight_card_city)
        val airportDistance = holderView.findViewById<TextView>(R.id.flight_card_airport_distance)
        val airportCode = holderView.findViewById<TextView>(R.id.flight_card_airport_code)
        locationDestination.text = airportsList[position].names[0]
        airportDistance.text = airportsList[position].distanceValue.toString() + " " + airportsList[position].distanceUnit
        airportCode.text = airportsList[position].airportCode
        card.setOnClickListener{
            onAirportChosen(airportsList[position])
        }
    }

    public fun setData(data: List<Airport>) {
        airportsList = data
        notifyDataSetChanged()
    }
}