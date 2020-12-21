package com.travelplanner.ui.poi

import android.os.Bundle
import android.util.Log
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.ImageView
import android.widget.LinearLayout
import android.widget.TextView
import android.widget.Toast
import androidx.fragment.app.Fragment
import androidx.recyclerview.widget.LinearLayoutManager
import androidx.recyclerview.widget.RecyclerView
import com.bumptech.glide.Glide
import com.travelplanner.R
import com.travelplanner.di.DIContainer.travelApiService
import com.travelplanner.models.Poi
import com.travelplanner.utils.applySchedulers

class PoiFragment : Fragment(){

    override fun onCreateView(inflater: LayoutInflater, container: ViewGroup?, savedInstanceState: Bundle?): View? {
        val v = inflater.inflate(R.layout.fragment_poi, container, false)
        var poi: Poi? = activity?.intent?.getParcelableExtra(EXTRA_POI)
        var travelId: String? = activity?.intent?.getStringExtra(EXTRA_TRAVEL_ID)
        val title = v.findViewById<TextView>(R.id.poi_title)
        title.text = poi?.name
        val description = v.findViewById<TextView>(R.id.poi_description)
        description.text = poi?.snippet
        val price = v.findViewById<TextView>(R.id.poi_price)
        val priceRow = v.findViewById<LinearLayout>(R.id.poi_booking_info_price)
        val vendor = v.findViewById<TextView>(R.id.poi_vendor)
        val vendorRow = v.findViewById<LinearLayout>(R.id.poi_booking_info_vendor)
        if(poi?.price == "")
            priceRow.visibility = View.GONE
        else
            price.text = poi?.price
        if(poi?.vendorUrl == "")
            vendorRow.visibility = View.GONE
        else
            vendor.text = poi?.vendorUrl
        val recycler = v.findViewById<RecyclerView>(R.id.poi_recycler)
        val adapter = PoiAdaper()
        recycler.adapter = adapter
        recycler.layoutManager = LinearLayoutManager(context)
        val image = v.findViewById<ImageView>(R.id.poi_image)
        if(poi?.photoUrl == null || poi?.photoUrl == "")
            image.visibility = View.GONE
        else
            Glide
                .with(v.context)
                .load(poi?.photoUrl)
                .into(image)
        val favourite =  v.findViewById<ImageView>(R.id.poi_liked_icon)
        favourite.setOnClickListener {
            addToFavourites(
                poi?.poiId,
                travelId
            )
        }
        return v
    }

    fun addToFavourites(poiId: String?, travelId: String?){
        if(poiId == null || travelId == null ) return
        travelApiService.postToSeeItem(poiId, travelId)
            .applySchedulers()
            .subscribe ({ t ->
                Toast.makeText(context, "Point added to list", Toast.LENGTH_SHORT).show()
            },{
                Log.e("ToSeeListViewModel", it.message.toString())
            })
    }

    companion object{
        val EXTRA_POI = "poi"
        val EXTRA_TRAVEL_ID = "travel_id"
    }
}