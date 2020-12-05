package com.travelplanner.ui.travel

import android.content.Intent
import android.os.Bundle
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.TextView
import androidx.constraintlayout.widget.ConstraintLayout
import androidx.fragment.app.Fragment
import androidx.lifecycle.Observer
import androidx.lifecycle.ViewModelProvider
import com.google.android.material.chip.Chip
import com.travelplanner.R
import com.travelplanner.ui.cityWalk.CityWalkActivity
import com.travelplanner.ui.cityWalk.CityWalkAdapter
import com.travelplanner.ui.cityWalk.CityWalkFragment
import com.travelplanner.ui.dayPlan.DayPlanActivity
import com.travelplanner.ui.dayPlan.DayPlanFragment
import com.travelplanner.ui.hotel.HotelActivity
import com.travelplanner.ui.hotel.HotelFragment

abstract class TravelFragmentBase : Fragment() {

    protected lateinit var travelViewModel: TravelViewModelBase

    abstract fun getViewModel(): TravelViewModelBase

    override fun onCreateView(
            inflater: LayoutInflater,
            container: ViewGroup?,
            savedInstanceState: Bundle?
    ): View? {
        travelViewModel = getViewModel()
        travelViewModel.initTravel()
        val root = inflater.inflate(R.layout.fragment_travel, container, false)
        val noIncTravel = root?.findViewById<ConstraintLayout>(R.id.no_incoming_travel)
        noIncTravel?.visibility = View.GONE
        val textView: TextView = root.findViewById(R.id.travel_date)
        travelViewModel.date.observe(viewLifecycleOwner, Observer {
            textView.text = it
        })
        val dayPlanButton = root.findViewById<Chip>(R.id.day_plans_chip)
        val cityWalkButton = root.findViewById<Chip>(R.id.city_walk_chip)
        val hotelButton = root.findViewById<Chip>(R.id.hotel_chip)
        travelViewModel.travel.observe(viewLifecycleOwner, Observer{t ->
            dayPlanButton.setOnClickListener{
                val intent = Intent(activity, DayPlanActivity::class.java)
                intent.putExtra(DayPlanFragment.EXTRA_TRAVEL_ID, t?.travelId)
                activity?.startActivity(intent)
            }
            cityWalkButton.setOnClickListener{
                val intent = Intent(activity, CityWalkActivity::class.java)
                intent.putExtra(CityWalkFragment.EXTRA_TRAVEL_ID, t?.travelId)
                activity?.startActivity(intent)
            }
            hotelButton.setOnClickListener{
                val intent = Intent(activity, HotelActivity::class.java)
                intent.putExtra(HotelFragment.EXTRA_TRAVEL_ID, t?.travelId)
                activity?.startActivity(intent)
            }
        })
        return root
    }


}