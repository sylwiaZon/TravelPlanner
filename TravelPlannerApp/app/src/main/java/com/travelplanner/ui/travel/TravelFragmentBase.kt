package com.travelplanner.ui.travel

import android.os.Bundle
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.TextView
import androidx.fragment.app.Fragment
import androidx.lifecycle.Observer
import androidx.lifecycle.ViewModelProvider
import com.travelplanner.R
import com.travelplanner.models.Travel

class TravelFragment : Fragment() {

    private lateinit var travelViewModel: TravelViewModel

    fun setTravel(travel: Travel){
        travelViewModel.setTravel(travel)
    }

    override fun onCreateView(
            inflater: LayoutInflater,
            container: ViewGroup?,
            savedInstanceState: Bundle?
    ): View? {
        travelViewModel =
                ViewModelProvider(this).get(TravelViewModel::class.java)
        val root = inflater.inflate(R.layout.fragment_travel, container, false)
        val textView: TextView = root.findViewById(R.id.travel_date)
        travelViewModel.date.observe(viewLifecycleOwner, Observer {
            textView.text = it
        })
        return root
    }
}