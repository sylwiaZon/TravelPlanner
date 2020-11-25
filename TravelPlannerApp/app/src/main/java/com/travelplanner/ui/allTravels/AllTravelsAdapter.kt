package com.travelplanner.ui.allTravels

import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.TextView
import androidx.recyclerview.widget.RecyclerView
import com.bumptech.glide.Glide
import com.travelplanner.R
import com.travelplanner.models.Travel

class AllTravelsAdapter : RecyclerView.Adapter<AllTravelsAdapter.ViewHolder>() {
    class ViewHolder(itemView: View) : RecyclerView.ViewHolder(itemView) {

    }

    private var travelsList:  List<Travel> = emptyList()

    override fun onCreateViewHolder(parent: ViewGroup, viewType: Int): ViewHolder {
       val itemView: View = LayoutInflater.from(parent.context).inflate(R.layout.item_all_travels, parent, false)
       return ViewHolder(itemView)
    }

    override fun getItemCount(): Int {
        return travelsList.size
    }

    override fun onBindViewHolder(holder: ViewHolder, position: Int) {
        val holderView = holder.itemView
        holderView.findViewById<TextView>(R.id.item_destination).text = travelsList[position].travelDestination.city
        holderView.findViewById<TextView>(R.id.item_dates).text = travelsList[position].date.toString()
        Glide
                .with(holderView.context)
                .load("https://farm5.staticflickr.com/4064/4437116960_ef1b509217_o.jpg")
                .into(holderView.findViewById(R.id.item_image));
    }

    public fun setData(data: List<Travel>){
        travelsList = data
        notifyDataSetChanged()
    }
}