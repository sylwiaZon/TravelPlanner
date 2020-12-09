package com.travelplanner.ui.newTravel

import android.os.Bundle
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.TextView
import androidx.fragment.app.Fragment
import androidx.lifecycle.Observer
import androidx.lifecycle.ViewModelProvider
import com.travelplanner.R

class NewTravelFragment : Fragment() {

    private lateinit var newTravelViewModel: NewTravelViewModel

    override fun onCreateView(
            inflater: LayoutInflater,
            container: ViewGroup?,
            savedInstanceState: Bundle?
    ): View? {
        newTravelViewModel =
                ViewModelProvider(this).get(NewTravelViewModel::class.java)
        val root = inflater.inflate(R.layout.fragment_new_travel, container, false)
        newTravelViewModel.text.observe(viewLifecycleOwner, Observer {
        })
        return root
    }
}