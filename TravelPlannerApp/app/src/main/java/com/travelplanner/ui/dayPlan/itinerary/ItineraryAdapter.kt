package com.travelplanner.ui.dayPlan.itinerary

import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.ImageView
import android.widget.TextView
import androidx.recyclerview.widget.RecyclerView
import com.bumptech.glide.Glide
import com.travelplanner.R
import com.travelplanner.models.Itinerary
import com.travelplanner.models.ItineraryItem
import java.time.format.DateTimeFormatter
import java.time.format.FormatStyle

class ItineraryAdapter : RecyclerView.Adapter<ItineraryAdapter.ViewHolder>(){
    class ViewHolder(itemView: View) : RecyclerView.ViewHolder(itemView) {

    }
    private var itineraryItemsList:  List<ItineraryItem> = emptyList()

    override fun onCreateViewHolder(parent: ViewGroup, viewType: Int): ViewHolder {
        val itemView: View = LayoutInflater.from(parent.context).inflate(R.layout.item_day_plan_itinerary, parent, false)
        return ViewHolder(itemView)
    }

    override fun getItemCount(): Int {
        return itineraryItemsList.size
    }

    override fun onBindViewHolder(holder: ViewHolder, position: Int) {
        val holderView = holder.itemView
        val title = holderView.findViewById<TextView>(R.id.itinerary_title)
        val poiTitle = holderView.findViewById<TextView>(R.id.itinerary_poi_title)
        val description = holderView.findViewById<TextView>(R.id.itinerary_description)
        title.text = itineraryItemsList[position].title
        poiTitle.text = itineraryItemsList[position].poi.name
        description.text = itineraryItemsList[position].description
        Glide
            .with(holderView.context)
            .load(itineraryItemsList[position].poi.photoUrl)
            .into(holderView.findViewById(R.id.itinerary_image));
    }

    public fun setData(data: List<ItineraryItem>){
        itineraryItemsList = data
        notifyDataSetChanged()
    }
}