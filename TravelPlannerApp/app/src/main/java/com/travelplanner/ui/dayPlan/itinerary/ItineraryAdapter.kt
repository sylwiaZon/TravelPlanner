package com.travelplanner.ui.dayPlan.itinerary

import android.content.Context
import android.content.Intent
import android.media.Image
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
import com.travelplanner.ui.poi.PoiActivity
import com.travelplanner.ui.poi.PoiFragment
import java.time.format.DateTimeFormatter
import java.time.format.FormatStyle

class ItineraryAdapter(val travelId: String?, val onFavouriteClicked: (poiId: String) -> Unit) : RecyclerView.Adapter<ItineraryAdapter.ViewHolder>(){
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
        if(itineraryItemsList[position].title == "")
            title.visibility = View.GONE
        else
            title.text = itineraryItemsList[position].title
        poiTitle.text = itineraryItemsList[position].poi.name
        description.text = itineraryItemsList[position].description
        val image = holderView.findViewById<ImageView>(R.id.itinerary_image)
        if(itineraryItemsList[position].poi.photoUrl == null || itineraryItemsList[position].poi.photoUrl == "")
            image.visibility = View.GONE
        else
            Glide
                .with(holderView.context)
                .load(itineraryItemsList[position].poi.photoUrl)
                .into(image)
        val seePoi = holderView.findViewById<TextView>(R.id.day_plan_itinerary_see_poi)
        seePoi.setOnClickListener {
            val intent = Intent(holderView.context, PoiActivity::class.java)
            intent.putExtra(PoiFragment.EXTRA_POI, itineraryItemsList[position].poi)
            intent.putExtra(PoiFragment.EXTRA_TRAVEL_ID, travelId)
            holderView.context.startActivity(intent)
        }
        val liked = holderView.findViewById<ImageView>(R.id.itinerary_poi_liked_icon)
        liked.setOnClickListener{
            onFavouriteClicked(itineraryItemsList[position].poi.poiId)
        }
    }

    public fun setData(data: List<ItineraryItem>){
        itineraryItemsList = data.reversed()
        notifyDataSetChanged()
    }
}