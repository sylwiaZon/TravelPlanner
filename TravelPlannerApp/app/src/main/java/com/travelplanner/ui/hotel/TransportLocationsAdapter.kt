package com.travelplanner.ui.hotel

import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.TextView
import androidx.recyclerview.widget.LinearLayoutManager
import androidx.recyclerview.widget.RecyclerView
import com.travelplanner.R
import com.travelplanner.models.HotelTransport
import com.travelplanner.models.TransportLocations
import com.travelplanner.models.Travel

class TransportLocationsAdapter() : RecyclerView.Adapter<TransportLocationsAdapter.ViewHolder>() {
    class ViewHolder(itemView: View) : RecyclerView.ViewHolder(itemView) {

    }

    private var locationsList: List<TransportLocations> = emptyList()

    override fun onCreateViewHolder(parent: ViewGroup, viewType: Int): ViewHolder {
        val itemView: View = LayoutInflater.from(parent.context).inflate(R.layout.item_transport, parent, false)
        return ViewHolder(itemView)
    }

    override fun getItemCount(): Int {
        return locationsList.size
    }

    override fun onBindViewHolder(holder: ViewHolder, position: Int) {
        val holderView = holder.itemView
        val transportName = holderView.findViewById<TextView>(R.id.item_transport_name)
        val distance = holderView.findViewById<TextView>(R.id.item_transport_distance_value)
        val distanceRow = holderView.findViewById<TextView>(R.id.item_transport_distance_value)
        val time = holderView.findViewById<TextView>(R.id.item_transport_distance_in_minutes_value)
        val timeRow = holderView.findViewById<TextView>(R.id.item_transport_distance_in_minutes_value)
        if(locationsList[position].name != null){
            transportName.text = locationsList[position].name
        } else {
            transportName.visibility = View.GONE
        }
        if(locationsList[position].distance != null || locationsList[position].distance != ""){
            distance.text = locationsList[position].distance
        } else {
            distanceRow.visibility = View.GONE
        }
        if(locationsList[position].distanceInTime != null || locationsList[position].distanceInTime != ""){
            time.text = locationsList[position].distanceInTime
        } else {
            timeRow.visibility = View.GONE
        }
    }

    public fun setData(data: List<TransportLocations>) {
        locationsList = data
        notifyDataSetChanged()
    }
}