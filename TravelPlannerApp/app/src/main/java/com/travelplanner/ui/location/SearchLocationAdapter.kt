package com.travelplanner.ui.location

import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.TextView
import androidx.recyclerview.widget.RecyclerView
import com.google.android.material.card.MaterialCardView
import com.travelplanner.R
import com.travelplanner.models.Location

class SearchLocationAdapter(val onLocationChosen: (Location) -> Unit): RecyclerView.Adapter<SearchLocationAdapter.ViewHolder>() {
    class ViewHolder(itemView: View) : RecyclerView.ViewHolder(itemView) {}

    private var locationsList: List<Location> = emptyList()

    override fun onCreateViewHolder(parent: ViewGroup, viewType: Int): ViewHolder {
        val itemView: View = LayoutInflater.from(parent.context).inflate(R.layout.item_search_location, parent, false)
        return ViewHolder(itemView)
    }

    override fun getItemCount(): Int {
        return locationsList.size
    }

    override fun onBindViewHolder(holder: ViewHolder, position: Int) {
        val holderView = holder.itemView
        val card = holderView.findViewById<MaterialCardView>(R.id.search_location_card)
        val locationDestination = holderView.findViewById<TextView>(R.id.search_location_destination)
        val locationDescription = holderView.findViewById<TextView>(R.id.search_location_description)
        locationDestination.text = locationsList[position].name + ", " + locationsList[position].countryId
        locationDescription.text = locationsList[position].snippet
        card.setOnClickListener{
            onLocationChosen(locationsList[position])
        }
    }

    public fun setData(data: List<Location>) {
        locationsList = data
        notifyDataSetChanged()
    }
}