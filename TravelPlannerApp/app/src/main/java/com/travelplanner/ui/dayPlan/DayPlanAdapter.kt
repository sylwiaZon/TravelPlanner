package com.travelplanner.ui.dayPlan

import android.content.Context
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.ImageView
import android.widget.LinearLayout
import android.widget.TextView
import androidx.recyclerview.widget.LinearLayoutManager
import androidx.recyclerview.widget.RecyclerView
import com.google.android.material.card.MaterialCardView
import com.travelplanner.R
import com.travelplanner.models.Itinerary
import com.travelplanner.ui.dayPlan.itinerary.ItineraryAdapter
import java.time.format.DateTimeFormatter
import java.time.format.FormatStyle

class DayPlanAdapter(val travelId: String?, val onFavouriteClicked: (poiId: String) -> Unit) : RecyclerView.Adapter<DayPlanAdapter.ViewHolder>() {

    class ViewHolder(itemView: View, var isOpen: Boolean) : RecyclerView.ViewHolder(itemView) {

    }
    private var itinerariesList:  List<Itinerary> = emptyList()

    override fun onCreateViewHolder(parent: ViewGroup, viewType: Int): ViewHolder {
        val itemView: View = LayoutInflater.from(parent.context).inflate(R.layout.item_day_plan, parent, false)
        return ViewHolder(itemView, false)
    }

    override fun getItemCount(): Int {
        return itinerariesList.size
    }

    override fun onBindViewHolder(holder: ViewHolder, position: Int) {
        val holderView = holder.itemView
        val formatter = DateTimeFormatter.ofLocalizedDate(FormatStyle.LONG)
        val recycler = holderView.findViewById<RecyclerView>(R.id.day_plan_itinerary_recycler)
        val adapter = ItineraryAdapter(travelId, onFavouriteClicked)
        itinerariesList[position].itineraryItems?.let {
            adapter.setData(it)
        }
        recycler.adapter = adapter
        recycler.layoutManager = LinearLayoutManager(holderView.context)
        val downArrow = holderView.findViewById<ImageView>(R.id.day_plan_arrow_down)
        val upArrow = holderView.findViewById<ImageView>(R.id.day_plan_arrow_up)
        if(!holder.isOpen){
            upArrow.visibility = View.GONE
            downArrow.visibility = View.VISIBLE
            recycler.visibility = View.GONE
        } else {
            upArrow.visibility = View.VISIBLE
            downArrow.visibility = View.GONE
            recycler.visibility = View.VISIBLE
        }
        holderView.setOnClickListener{
            if(!holder.isOpen) {
                holder.isOpen = true
                upArrow.visibility = View.GONE
                downArrow.visibility = View.VISIBLE
                recycler.visibility = View.GONE
            } else {
                holder.isOpen = false
                upArrow.visibility = View.VISIBLE
                downArrow.visibility = View.GONE
                recycler.visibility = View.VISIBLE
            }
        }
        val date = itinerariesList[position].date.format(formatter)
        val holderDate = holderView.findViewById<TextView>(R.id.day_plan_date)
        holderDate.text = date
    }

    public fun setData(data: List<Itinerary>){
        itinerariesList = data.reversed()
        notifyDataSetChanged()
    }
}