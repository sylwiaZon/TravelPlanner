package com.travelplanner.ui.poi

import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.TextView
import androidx.recyclerview.widget.RecyclerView
import com.bumptech.glide.Glide
import com.travelplanner.R
import com.travelplanner.models.Attribution
import com.travelplanner.models.ItineraryItem

class PoiAdaper : RecyclerView.Adapter<PoiAdaper.ViewHolder>(){
    class ViewHolder(itemView: View) : RecyclerView.ViewHolder(itemView) {

    }
    private var attributionList:  List<Attribution> = emptyList()

    override fun onCreateViewHolder(parent: ViewGroup, viewType: Int): ViewHolder {
        val itemView: View = LayoutInflater.from(parent.context).inflate(R.layout.item_poi_attribution, parent, false)
        return ViewHolder(itemView)
    }

    override fun getItemCount(): Int {
        return attributionList.size
    }

    override fun onBindViewHolder(holder: ViewHolder, position: Int) {
        val holderView = holder.itemView
        val source = holderView.findViewById<TextView>(R.id.poi_attribution_source)
        val url = holderView.findViewById<TextView>(R.id.poi_attribution_url)
        source.text = attributionList[position].source
        url.text = attributionList[position].url
    }

    public fun setData(data: List<Attribution>){
        attributionList = data
        notifyDataSetChanged()
    }
}