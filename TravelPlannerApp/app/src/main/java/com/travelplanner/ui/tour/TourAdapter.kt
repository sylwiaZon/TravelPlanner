package com.travelplanner.ui.tour

import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.LinearLayout
import android.widget.TextView
import androidx.recyclerview.widget.RecyclerView
import com.travelplanner.R
import com.travelplanner.models.Tour

class TourAdapter() : RecyclerView.Adapter<TourAdapter.ViewHolder>() {
    class ViewHolder(itemView: View) : RecyclerView.ViewHolder(itemView) {

    }

    private var toursList: List<Tour> = emptyList()

    override fun onCreateViewHolder(parent: ViewGroup, viewType: Int): ViewHolder {
        val itemView: View = LayoutInflater.from(parent.context).inflate(R.layout.item_tour, parent, false)
        return ViewHolder(itemView)
    }

    override fun getItemCount(): Int {
        return toursList.size
    }

    override fun onBindViewHolder(holder: ViewHolder, position: Int) {
        val holderView = holder.itemView
        val title = holderView.findViewById<TextView>(R.id.tour_name)
        title.text = toursList[position].name
        val description = holderView.findViewById<TextView>(R.id.tour_description)
        if(toursList[position].intro == null || toursList[position].intro == "")
            description.visibility = View.GONE
        else
            description.text = toursList[position].intro
        val price = holderView.findViewById<TextView>(R.id.tour_price)
        price.text = toursList[position].price + " " + toursList[position].priceCurrency
        val duration = holderView.findViewById<TextView>(R.id.tour_duration)
        val durationRow = holderView.findViewById<LinearLayout>(R.id.tour_duration_row)
        if(toursList[position].durationUnit == null)
            durationRow.visibility = View.GONE
        else
            duration.text = toursList[position].duration.toString() + " " + toursList[position].durationUnit
        val vendor = holderView.findViewById<TextView>(R.id.tour_vendor_url)
        vendor.text = toursList[position].vendorTourUrl
    }

    public fun setData(data: List<Tour>) {
        toursList = data
        notifyDataSetChanged()
    }
}