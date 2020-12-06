package com.travelplanner.ui.localHighlights

import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.ImageView
import android.widget.LinearLayout
import android.widget.TextView
import androidx.recyclerview.widget.LinearLayoutManager
import androidx.recyclerview.widget.RecyclerView
import com.bumptech.glide.Glide
import com.travelplanner.R
import com.travelplanner.models.Poi
import com.travelplanner.ui.poi.PoiAdaper

class LocalHighlightsAdapter() : RecyclerView.Adapter<LocalHighlightsAdapter.ViewHolder>() {
    class ViewHolder(itemView: View) : RecyclerView.ViewHolder(itemView) {

    }

    private var poisList: List<Poi> = emptyList()

    override fun onCreateViewHolder(parent: ViewGroup, viewType: Int): ViewHolder {
        val itemView: View = LayoutInflater.from(parent.context).inflate(R.layout.fragment_poi, parent, false)
        return ViewHolder(itemView)
    }

    override fun getItemCount(): Int {
        return poisList.size
    }

    override fun onBindViewHolder(holder: ViewHolder, position: Int) {
        val holderView = holder.itemView
        val title = holderView.findViewById<TextView>(R.id.poi_title)
        title.text = poisList[position].name
        val description = holderView.findViewById<TextView>(R.id.poi_description)
        description.text = poisList[position].snippet
        val price = holderView.findViewById<TextView>(R.id.poi_price)
        val priceRow = holderView.findViewById<LinearLayout>(R.id.poi_booking_info_price)
        val vendor = holderView.findViewById<TextView>(R.id.poi_vendor)
        val vendorRow = holderView.findViewById<LinearLayout>(R.id.poi_booking_info_vendor)
        val booking = holderView.findViewById<LinearLayout>(R.id.poi_booking_info)
        if(poisList[position].price == "" || poisList[position].price == null)
            priceRow.visibility = View.GONE
        else
            price.text = poisList[position].price
        if(poisList[position].vendorUrl == "" || poisList[position].vendorUrl == null)
            vendorRow.visibility = View.GONE
        else
            vendor.text = poisList[position].vendorUrl
        if((poisList[position].price == "" || poisList[position].price == null) && (poisList[position].vendorUrl == "" || poisList[position].vendorUrl == null))
            booking.visibility = View.GONE
        val recycler = holderView.findViewById<RecyclerView>(R.id.poi_recycler)
        val adapter = PoiAdaper()
        recycler.adapter = adapter
        recycler.layoutManager = LinearLayoutManager(holderView.context)
        val image = holderView.findViewById<ImageView>(R.id.poi_image)
        if(poisList[position].photoUrl == null || poisList[position].photoUrl == "")
            image.visibility = View.GONE
        else
            Glide
                    .with(holderView.context)
                    .load(poisList[position].photoUrl)
                    .into(image)
    }

    public fun setData(data: List<Poi>) {
        poisList = data
        notifyDataSetChanged()
    }
}